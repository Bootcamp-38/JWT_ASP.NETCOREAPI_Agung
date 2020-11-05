function Login() {
    //var User = new Object();
    //User.Email = $('#email').val();
    //User.Password = $('#password').val();
    var UserRoleVM = new Object();
    UserRoleVM.User_Email = $('#email').val();
    UserRoleVM.User_password = $('#password').val();
   
    $.ajax({        
        //url: '/Home/Get/',
        url: '/Login/Get/',
        type: "Post",
        data: UserRoleVM
    }).then((resolve) => {
        debugger;
        window.Location = "https://localhost:44390/Home/About/"
        console.log(resolve);
    }).catch((error) => {
        console.error(error);
    });
    //$.ajax({
    //    type: "Post",
    //    url: '/Login/Login/',
    //    data: User
    //}).then((result) => {
    //    if (User.Email != "") {
    //        if (result.StatusCode == 200) {
    //            Swal.fire({
    //                position: 'center',
    //                type: 'success',
    //                title: 'Login Success'
    //            });
    //        } else {
    //            Swal.fire('Error', 'Failed to Input', 'Error');
    //        }
    //    } else {
    //        Swal.fire('Error', 'Failed To Input', 'Error');
    //        //ClearScreen();
    //    }

    //});
}