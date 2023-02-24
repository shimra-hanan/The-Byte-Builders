<?php
$dbHost="localhost";
$dbUser="root";
$dbPss="";
$dbName="duothon";

$conn=mysqli_connect($dbUser,$dbPass,$dbName);

if(!conn){
    die("Could not connect to the database");
}

?>