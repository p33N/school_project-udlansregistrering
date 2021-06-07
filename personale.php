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
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <title>Udlånsregistrering</title>
        <link rel="stylesheet" href="style/stylesheets.css">

        <link rel="shortcut icon" href="favicon.ico" />
        <link href="https://fonts.googleapis.com/css2?family=Odibee+Sans&display=swap" rel="stylesheet">
    </head>

    <body>
        <div class="Container">
            <div class="header">
                <div id="banner">
                    <img src="images/banner.png" alt="Banner" height="100%" width="100%">
                </div>
                <div id="menu">
                    <ul>
                        <li><a href="index.php">Start</a></li>
                        <li><a href="produkter.php">Produkter</a></li>
                        <li><a href="personale.php">Personale</a></li>
                        <li><a href="omos.php">Om os</a></li>
                    </ul>
                </div>
            </div>
            <div class="content">

                <?php

                    $sql = "SELECT * FROM personale ORDER BY efternavn";

                    if ($res = $mysqli -> query($sql)) {
                        while ($obj = $res -> fetch_object()) {
                        printf("%s (%s)\n", $obj->personalenummer, $obj->efternavn, $obj->fornavn, $obj->telefonnummer);
                        }
                        
                        $res -> free_result();
                    }

                    $mysqli -> close();

                ?>

            </div>
            <div class="footer">
                <p><a href="#">Webkreez.dev</a> - Skoleprojekt © Copyright 2021</p>
            </div>
        </div>
    </body>
</html>