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
                    
                    <?php include 'includes/navbar.php';?>
                
                </div>
            </div>
            <div class="content">

                <div class="scrollbox">
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
                                        $("#productstable").append("<tr> <td> " + element.computerId + " </td> </tr> ");
                            
                                        });
                                    }
                                });
                                
                            </script>
                    </table>
                </div>

                <form  id="productform-edit">
                    <label for="id">ID:</label><br>
                    <input type="text" id="id" name="id" ><br>
                    <label for="maerke">Mærke:</label><br>
                    <input type="text" id="maerke" name="maerke" ><br>
                    <label for="model">Model:</label><br>
                    <input type="text" id="model" name="model" ><br>
                    <label for="status">Status:</label><br>
                    <input type="text" id="status" name="status" ><br>
                    <label for="laaner">Låner:</label><br>
                    <input type="text" id="laaner" name="laaner" ><br>
                    <input type="submit" id="btn-ret" value="Ændre">
                    <input type="submit" id="btn-slet" value="Slet">
                </form> 

                <form id="productform">
                    <label for="id">ID:</label><br>
                    <input type="text" id="id" name="ComputerId" ><br>
                    <label for="maerke">Mærke:</label><br>
                    <input type="text" id="maerke" name="Brand" ><br>
                    <label for="model">Model:</label><br>
                    <input type="text" id="model" name="Model" ><br>
                    <input type="hidden" name="StatusID" value="0">
                    <button id="create" >Opret</button>             
                </form> 
                
                <script>
                 $.fn.serializeObject = function() {
                    var o = {};
                    var a = this.serializeArray();
                    $.each(a, function() {
                        if (o[this.name]) {
                            if (!o[this.name].push) {
                                o[this.name] = [o[this.name]];
                            }
                            o[this.name].push(this.value || '');
                        } else {
                            o[this.name] = this.value || '';
                        }
                    });
                    return o;
                };
                        $("#create").click(function(){
                            event.preventDefault();
                            var myData = $("#productform").serializeObject(); 
                            $(this).closest('form').find("input[type=text], textarea").val("");
                            $.ajax({
                            type: "POST",
                            url:"http://10.130.16.147:57414/api/computer",
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            data:  JSON.stringify(myData) ,
                            contentType: "application/json",
                            dataType: "json",
                            success: function(result){
                                alert("pc was inserted")
                            },
                            error: function (errMsg) {
                                console.log(errMsg); 
                                
                            }
                            
                            }); 
                    
                        }); 

                </script>


            </div>
            <div class="footer">
                <?php include 'includes/footer.php';?>
            </div>
        </div>
    </body>
</html>