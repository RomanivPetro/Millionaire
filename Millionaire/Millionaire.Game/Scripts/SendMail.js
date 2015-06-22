function SendMail(sRecipientMail) {   
    PageMethods.SendMail(sRecipientMail, OnRequestComplete, OnError);  
}

function OnRequestComplete() {
    alert(["Лист відправлено. Очікуйте на відповідь"]);
    var element = document.getElementById('btnHelp2');
    element.className = 'help2u';
    element.disabled = true;
}

function OnError() {
    alert(["Помилка відправлення листа!"]);
}

function validateEmail(email) {
    var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
    return re.test(email);
}
