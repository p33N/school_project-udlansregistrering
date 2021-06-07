<?php

// SQL connection
$mysqli = new mysqli("localhost","root","root","udlaan");

// Check connection
if ($mysqli -> connect_errno) {
    echo "Failed to connect to MySQL: " . $mysqli -> connect_error;

    exit();
}

?>
<html>
    <head>
        <!--- META --->
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

        <!--- STYLE --->
        <title>Udlånsregistrering</title>
        <link rel="shortcut icon" href="favicon.ico" />
        <link rel="stylesheet" href="style/stylesheets.css">

        <!--- LINKS --->
        <link href="https://fonts.googleapis.com/css2?family=Odibee+Sans&display=swap" rel="stylesheet">
    </head>

    <body>
        <div class="Container">
            <div class="header">
                <div id="banner">
                    <img src="images/banner.png" alt="Banner" height="100%" width="100%">
                </div>
                <div id="menu">
                    
                    <?php include 'includes/navbar.php';?>
                
                </div>
            </div>
            <div class="content">

            

            </div>
            <div class="footer">
                <p><a href="#">Webkreez.dev</a> - Skoleprojekt © Copyright 2021</p>
            </div>
        </div>
    </body>
</html>