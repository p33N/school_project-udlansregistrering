<?php

?>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <title>Udlånsregistrering</title>
        <link rel="stylesheet" href="style/stylesheets.css">

        <link rel="shortcut icon" href="favicon.ico" />
        <link href="https://fonts.googleapis.com/css2?family=Odibee+Sans&display=swap" rel="stylesheet">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

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

                <table id="productstable">
                    <tr>
                        <th>Computere</th>
                    </tr>
                <!-- API call --> 
                    <script> 
                        $.ajax({
                            url:"http://10.130.16.147:57414/api/computer",
                            type: "GET",
                            dataType: "json",
                            cache: false,
                            success: function(result){
                                result.forEach(element => {
                                    $("#productstable").append("<tr> <td> " + element.computerId + "</td> </tr> ");
                                });
                            }
                        }); 
                    </script> 
                </table>

                <form action="functions/edit_form.php" id="productform">
                    <label for="id">ID:</label><br>
                    <input type="text" id="id" name="id" value="John"><br>
                    <label for="maerke">Mærke:</label><br>
                    <input type="text" id="maerke" name="maerke" value="John"><br>
                    <label for="model">Model:</label><br>
                    <input type="text" id="model" name="model" value="John"><br>
                    <label for="status">Status:</label><br>
                    <input type="text" id="status" name="status" value="John"><br>
                    <label for="laaner">Låner:</label><br>
                    <input type="text" id="laaner" name="laaner" value="John"><br>
                    <input type="submit" id="btn-ret" value="Ændre">
                    <input type="submit" id="btn-slet" value="Slet">
                </form> 

                <form action="functions/create_form.php" id="productform">
                    <label for="id">ID:</label><br>
                    <input type="text" id="id" name="id" value="John"><br>
                    <label for="maerke">Mærke:</label><br>
                    <input type="text" id="maerke" name="maerke" value="John"><br>
                    <label for="model">Model:</label><br>
                    <input type="text" id="model" name="model" value="John"><br>
                    <input type="submit" id="btn-opret" value="oPr3T">
                </form> 

            </div>
            <div class="footer">
                <p><a href="#">Webkreez.dev</a> © Copyright 2021</p>
            </div>
        </div>
    </body>
</html>