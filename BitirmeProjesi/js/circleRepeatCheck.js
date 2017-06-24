function checkcircle(str) {
    if (parseFloat(document.getElementById(str.id).value) <= 1) {
        document.getElementById(str.id).value = "";
        document.getElementById(str.id).focus();
        alert('Enter a number greater than 1');
        return false;
    }
}
