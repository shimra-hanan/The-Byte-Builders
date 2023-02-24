<?php

if(isset($POST['submit'])){
    //echo "clicked";
    require "conn.php";

    //collect data from the form
    $pharmacy_name=$_POST['pharmacy_username'];
    $email=$_POST['email'];
    $address=$_POST['address'];
    $phone_number=$_POST['phone_number'];
    $license_number=$_POST['license_number'];
    $password=$_POST['password'];
    $confirm_password=$_POST['confirm_password'];

    //error handler
    if(empty($pharmacy_name) || empty($password) || empty($confirm_password) || empty($license_number)){
        header("Location:signup.html error=emptyfields&pharmacy_name='.$pharmacy_name");
        exit();

        //check for invalid fields
    }elseif (!preg_match("/^[a-zA-Z0-9]*/",$username)){
        header("Location:signup.html error=invalidfields&pharmacy_name".$pharmacy_name);
        exit();
    }elseif($password!==$confirm_password){
        header("Location:signup.html error=passworddonotmatch&username".$pharmacy_name);
        exit();
        //check if the username is taken or not
    }else{
        $sql="SELECT pharmacy_name FROM pharmacy WHERE pharmacy_name = ?";
        $stmt=mysqli_stmt_init($conn);
        if(!mysqli_stmt_prepare($stmt,$sql)){
                header("Location:signup.html error=sqlerror");
                exit();
        }else{
            mysqli_stmt_bind_param($stmt,'s',$pharmacy_name);
            mysqli_stmt_execute($stmt);
            mysqli_stmt_store_result($stmt);
            $rowCount==mysqlit_stmt_num_rows($stmt);
            if($rowCount>0){
                header("Location:signup.html error=usernameistaken&pharmacy_name".$pharmacy_name);
                exit();
                //insert data into the database
            }else{
                $sql="INSERT INTO pharmacy (pharmacy_name,email,address,phone_number,license_number,password)values($pharmacy_name,$email,$address,$phone_number,$license_number,$password)";
                $stmt=mysqli_stmt_init($conn);
                if(!mysqli_stmt_prepare($stmt,$sql)){
                    header("Location:signup.html error=sqlerror");
                    exit();
                }else{
                    mysqli_stmt_bind_param($stmt,"sss",$pharmacy_name,$email,$address,$phone_number,$license_number,$password);
                    mysqli_stmt_execute($stmt);
                    header("Location:index.php success=registered");
                }
            }
        }
    }
}
?>