// ������ ��� �������� �������
const openLoginModalBtn = document.getElementById("openLoginModal");
const openRegisterModalBtn = document.getElementById("openRegisterModal");
const openFeedbackModalBtn = document.getElementById("openFeedbackModal");

// ������� ��� �������� �������� �����
openLoginModalBtn.onclick = function () {
    window.location.href = "/Client/Login";  // ������� �� �������� �����
}

// ������� ��� �������� �������� �����������
openRegisterModalBtn.onclick = function () {
    window.location.href = "/Client/Register";  // ������� �� �������� �����������
}

// ������� ��� �������� �������� ������
openFeedbackModalBtn.onclick = function () {
    window.location.href = "/Client/Feedback";  // ������� �� �������� ������
}


//�������� ������� �� ������
//async function login() {
//    const email = document.getElementById("loginEmail").value;
//    const password = document.getElementById("loginPassword").value;

//    const response = await fetch('https://localhost:7291/Client/login', {
//        method: 'POST',
//        headers: { 'Content-Type': 'application/json' },
//        body: JSON.stringify({ email, password })
//    });

//    if (response.ok) {
//        alert("�� ������� �����!");
//        loginModal.style.display = "none";
//    } else {
//        alert("������ �����: ��������� ������");
//    }
//}
//async function register() {
//    const name = document.getElementById("registerName").value;
//    const email = document.getElementById("registerEmail").value;
//    const phoneNumber = document.getElementById("registerNumber").value;
//    const password = document.getElementById("registerPassword").value;
//    const confirmPassword = document.getElementById("confirmPassword").value;

//    if (password !== confirmPassword) {
//        event.preventDefault(); // ������������� �������� �����
//        alert("������ �� ���������. ����������, ��������� ��������� ������.");
//    }

//    const response = await fetch('https://localhost:7291/Client/create', {
//        method: 'POST',
//        headers: { 'Content-Type': 'application/json' },
//        body: JSON.stringify({ name, email, phoneNumber, password })
//    });

//    if (response.ok) {
//        alert("����������� ������ �������!");
//        registerModal.style.display = "none";
//    } else {
//        alert("������ �����������: ��������� ������");
//    }
//}

//������� ������
function searchFunction() {
    const input = document.getElementById('search-input');
    const searchText = input.value;

    // ���� ���� ������, �� ���������� �����
    if (searchText === "") {
        alert("������� ����� ��� ������.");
        return;
    }

    // ����� ���������� ������� ������ ��������
    const found = window.find(searchText);

    // ���� ����� �� ������, ������� ���������
    if (!found) {
        alert("���������� �� �������.");
    }
}


// �������� � �������� ���������� ���� ������
//const feedbackModal = document.getElementById("feedbackModal");
//const openFeedbackModalBtn = document.getElementById("openFeedbackModal");
//const closeFeedbackModalBtn = document.getElementById("closeFeedbackModal");

//openFeedbackModalBtn.onclick = function () {
//    feedbackModal.style.display = "block";
//}

//closeFeedbackModalBtn.onclick = function () {
//    feedbackModal.style.display = "none";
//}

// �������� ��������� ���� ��� ����� ��� ����
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

// ������� ��� �������� ����������� ������������
async function checkUserAuthentication() {
    try {
        const response = await fetch('/Client/getUserName', {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        });

        if (response.ok) {
            const data = await response.json();
            displayUserName(data.name);  // ��������� ��� ������������
        }
    } catch (error) {
        console.error("������ ��� �������� ����������� ������������:", error);
    }
}

// ������� ��� ����������� ����� ������������
function displayUserName(userName) {
    const authSection = document.getElementById("authSection");
    authSection.innerHTML = `<span>����� ����������, ${userName}</span>
                             <button id="logoutButton">�����</button>`;

    // ��������� ���������� ������� ��� ������ ������
    document.getElementById("logoutButton").addEventListener("click", logout);
}

// ������� ��� ������ ������������
async function logout() {
    try {
        await fetch('/Client/logout', { method: 'POST' });  // ��������������, ��� ���� ����� ������
        location.reload();  // ������������� �������� ����� ������
    } catch (error) {
        console.error("������ ��� ������:", error);
    }
}

// ��������� ������ ����������� ��� �������� ��������
window.addEventListener("DOMContentLoaded", checkUserAuthentication);
