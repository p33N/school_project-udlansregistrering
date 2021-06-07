<?php

?>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <title>Udlånsregistrering</title>
        <link rel="stylesheet" href="style/stylesheets.css">
        <link rel="stylesheet" href="style/popupstyle.css">

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
                
                    <?php include 'includes/navbar.php';?>
                
            </div>
            </div>
            <div class="content">

                <table id="productstable">
                    <tr>
                        <th>Computere</th>
                    </tr>
                
                        <?php include 'includes/producttable.php';?>       
                    
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
                <?php include 'includes/footer.php';?>
            </div>
        </div>

        <script type="text/javascript">
            function openForm() {
                document.getElementById("productform").style.display = "block";
            }

            function closeForm() {
                document.getElementById("productform").style.display = "none";
            }
        </script>
    </body>
</html>