// JavaScript Document
function MouseEvent(N, Obj) {
    var sid = document.getElementById('selectid').value;
    if (N == 1) {
        Obj.className = 'inputOver';
    }
    else {
        Obj.className = 'input';
        document.getElementById('c' + sid).className = 'inputOver';
        document.getElementById('sc' + sid).className = 'inputOver';
    }
}

function CUrl(i) {
    document.getElementById('c' + document.getElementById('selectid').value).className = 'input';
    document.getElementById('sc' + document.getElementById('selectid').value).className = 'input';
    document.getElementById('c' + i).className = 'inputOver';
    document.getElementById('sc' + i).className = 'inputOver';
    document.getElementById('tbody' + document.getElementById('selectid').value).style.display = 'none';
    document.getElementById('tbody' + i).style.display = 'block';
    document.getElementById('selectid').value = i;
}


function MM_reloadPage(init) {
    if (init == true) {
        with (navigator) {
            if ((appName == "Netscape") && (parseInt(appVersion) == 4)) {
                document.MM_pgW = innerWidth; document.MM_pgH = innerHeight; onresize = MM_reloadPage;
            }
        }
    }
    else if (innerWidth != document.MM_pgW || innerHeight != document.MM_pgH) {
        location.reload();
    }
}

//
var imgheight;
var imgwidth;
document.ns = navigator.appName == "Netscape";
window.screen.width > 800 ? imgheight = 510 : imgheight = 250;
window.screen.width > 800 ? imgwidth = 120 : imgwidth = 745;

function myload() {
    if (navigator.appName == "Netscape") {
        document.mymenu.pageY = pageYOffset + window.innerHeight - imgheight;
        document.mymenu.pageX = +window.innerWidth - imgwidth;
    }
    else {
        mymenu.style.top = document.documentElement.offsetHeight - imgheight;
        mymenu.style.left = document.documentElement.offsetWidth - imgwidth;
    }
    leftmove();
}

function myover() {
    myselect.style.filter = 'alpha(opacity=100)';
    myselect.style.visibility = 'visible';
}

function myout() {
    if (window.screen.width == 1024) {
        myselect.style.filter = 'alpha(opacity=60)';
    }
    else {
        myselect.style.visibility = 'hidden';
    }
}

function leftmove() {
    if (document.ns) {
        document.mymenu.top = pageYOffset + window.innerHeight - imgheight
        document.mymenu.left = pageXOffset + window.innerWidth - imgwidth;
    }
    else {
        //alert(document.body.scrollTop);
        mymenu.style.top = document.documentElement.scrollTop + document.documentElement.offsetHeight - imgheight;
        mymenu.style.left = document.documentElement.scrollLeft + document.documentElement.offsetWidth - imgwidth;
    }
    setTimeout("leftmove();", 80);
}

function ExamSubmit(Str, TF) {
    if (TF == 0) {
        document.getElementById("ExamSubmit1").className = 'SubmitHidden';
        if (Str == '2') {
            document.getElementById("ExamSubmit2").className = 'SubmitShow';
        }
    }
    else {
        TimeStop();
        if (confirm('确认提交') == true) {
            document.form1.submit();
            document.getElementById("ExamSubmit1").className = 'SubmitHidden';
            if (Str == '2') {
                document.getElementById("submitPaper").className = 'SubmitShow';
            }
        }
        else {
            TimeStart();
        }
    }
}


