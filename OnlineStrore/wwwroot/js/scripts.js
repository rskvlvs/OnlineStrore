// Кнопки для открытия страниц
const openLoginModalBtn = document.getElementById("openLoginModal");
const openRegisterModalBtn = document.getElementById("openRegisterModal");
const openFeedbackModalBtn = document.getElementById("openFeedbackModal");

// Функция для открытия страницы входа
openLoginModalBtn.onclick = function () {
    window.location.href = "/Client/Login";  // Переход на страницу входа
}

// Функция для открытия страницы регистрации
openRegisterModalBtn.onclick = function () {
    window.location.href = "/Client/Register";  // Переход на страницу регистрации
}

// Функция для открытия страницы отзыва
openFeedbackModalBtn.onclick = function () {
    window.location.href = "/Client/Feedback";  // Переход на страницу отзыва
}


//отправка запроса на сервер
//async function login() {
//    const email = document.getElementById("loginEmail").value;
//    const password = document.getElementById("loginPassword").value;

//    const response = await fetch('https://localhost:7291/Client/login', {
//        method: 'POST',
//        headers: { 'Content-Type': 'application/json' },
//        body: JSON.stringify({ email, password })
//    });

//    if (response.ok) {
//        alert("Вы успешно вошли!");
//        loginModal.style.display = "none";
//    } else {
//        alert("Ошибка входа: проверьте данные");
//    }
//}
//async function register() {
//    const name = document.getElementById("registerName").value;
//    const email = document.getElementById("registerEmail").value;
//    const phoneNumber = document.getElementById("registerNumber").value;
//    const password = document.getElementById("registerPassword").value;
//    const confirmPassword = document.getElementById("confirmPassword").value;

//    if (password !== confirmPassword) {
//        event.preventDefault(); // Останавливаем отправку формы
//        alert("Пароли не совпадают. Пожалуйста, проверьте введенные данные.");
//    }

//    const response = await fetch('https://localhost:7291/Client/create', {
//        method: 'POST',
//        headers: { 'Content-Type': 'application/json' },
//        body: JSON.stringify({ name, email, phoneNumber, password })
//    });

//    if (response.ok) {
//        alert("Регистрация прошла успешно!");
//        registerModal.style.display = "none";
//    } else {
//        alert("Ошибка регистрации: проверьте данные");
//    }
//}

//Функция поиска
function searchFunction() {
    const input = document.getElementById('search-input');
    const searchText = input.value;

    // Если поле пустое, не производим поиск
    if (searchText === "") {
        alert("Введите текст для поиска.");
        return;
    }

    // Вызов встроенной функции поиска браузера
    const found = window.find(searchText);

    // Если текст не найден, выводим сообщение
    if (!found) {
        alert("Совпадений не найдено.");
    }
}


// Открытие и закрытие модального окна Отзыва
//const feedbackModal = document.getElementById("feedbackModal");
//const openFeedbackModalBtn = document.getElementById("openFeedbackModal");
//const closeFeedbackModalBtn = document.getElementById("closeFeedbackModal");

//openFeedbackModalBtn.onclick = function () {
//    feedbackModal.style.display = "block";
//}

//closeFeedbackModalBtn.onclick = function () {
//    feedbackModal.style.display = "none";
//}

// Закрытие модальных окон при клике вне окна
//window.onclick = function (event) {
//    if (event.target == loginModal) {
//        loginModal.style.display = "none";
//    }
//    if (event.target == registerModal) {
//        registerModal.style.display = "none";
//    }
//    if (event.target == feedbackModal) {
//        feedbackModal.style.display = "none";
//    }
//}

// Функция для проверки авторизации пользователя
async function checkUserAuthentication() {
    try {
        const response = await fetch('/Client/getUserName', {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        });

        if (response.ok) {
            const data = await response.json();
            displayUserName(data.name);  // Отобразим имя пользователя
        }
    } catch (error) {
        console.error("Ошибка при проверке авторизации пользователя:", error);
    }
}

// Функция для отображения имени пользователя
function displayUserName(userName) {
    const authSection = document.getElementById("authSection");
    authSection.innerHTML = `<span>Добро пожаловать, ${userName}</span>
                             <button id="logoutButton">Выйти</button>`;

    // Добавляем обработчик события для кнопки выхода
    document.getElementById("logoutButton").addEventListener("click", logout);
}

// Функция для выхода пользователя
async function logout() {
    try {
        await fetch('/Client/logout', { method: 'POST' });  // Предполагается, что есть метод выхода
        location.reload();  // Перезагружаем страницу после выхода
    } catch (error) {
        console.error("Ошибка при выходе:", error);
    }
}

// Проверяем статус авторизации при загрузке страницы
window.addEventListener("DOMContentLoaded", checkUserAuthentication);
