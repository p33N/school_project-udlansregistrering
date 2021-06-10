<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <title>Udlånsregistrering</title>
        <link rel="stylesheet" href="style/stylesheets.css">
        <link rel="stylesheet" href="style/productstylesheets.css">
        <link rel="stylesheet" href="style/studentstylesheets.css">

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
                    <table id="studentstable">
                        <tr>
                            <th>Elever</th>
                        </tr>
                            <!-- API call --> 
                            <script> 
                            
                                $.ajax({
                                url:"http://10.130.16.147:57414/api/student",
                                type: "GET",
                                dataType: "json",
                                cache: false,
                                success: function(result){
                                    result.forEach(element => {
                                        $("#studentstable").append("<tr> <td id='"+element.studentId+"' onclick='thisStudentbox(this.id)'> " + element.studentNumber + "  </td> </tr> ");
                            
                                        });
                                    }
                                });
                                
                            </script>
                    </table>
                </div>

                <form  id="studentform-edit">
                    <label for="name">number:</label><br>
                    <input type="text" id="number" name="number" ><br>
                    <label for="name">Navn:</label><br>
                    <input type="text" id="Navn" name="id" ><br>
                    <label for="adress">Adresse:</label><br>
                    <input type="text" id="maerke" name="maerke" ><br>
                    <label for="zipcode">Postnummer:</label><br>
                    <input type="text" id="model" name="model" ><br>
                    <label for="socialsecurity">Social Security:</label><br>
                    <input type="text" id="status" name="status" ><br>
                    <label for="email">Email:</label><br>
                    <input type="text" id="laaner" name="laaner" ><br>
                    <label for="class">Klasse:</label><br>
                    <input type="text" id="laaner" name="laaner" ><br>
                    <input type="submit" id="btn-ret" value="Ændre">
                    <input type="submit" id="btn-slet" value="Slet">
                </form> 

                <form id="studentform">

                    <label for="studentNumber">studentNumber:</label><br>
                    <input type="text" id="studentNumber" name="studentNumber" ><br>

                    <label for="studentName">studentName:</label><br>
                    <input type="text" id="studentName" name="studentName" ><br>

                    <label for="address">address:</label><br>
                    <input type="text" id="address" name="address" ><br>

                    <label for="zipCity">zipCity:</label><br>
                    <input type="text" id="zipCity" name="zipCity" ><br>

                    <label for="socialSecurity">socialSecurity:</label><br>
                    <input type="text" id="socialSecurity" name="socialSecurity" ><br>
                    
                    <label for="email">email:</label><br>
                    <input type="text" id="email" name="email" ><br>
                    
                    <label for="class">class:</label><br>
                    <input type="text" id="class" name="class" ><br>

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
                            var myData = $("#studentform").serializeObject(); 
                            $(this).closest('form').find("input[type=text], textarea").val("");
                            $.ajax({
                            type: "POST",
                            url:"http://10.130.16.147:57414/api/student",
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            data:  JSON.stringify(myData) ,
                            contentType: "application/json",
                            dataType: "json",
                            success: function(result){
                                alert("Elev tilføjet")
                            },
                            error: function (errMsg) {
                                console.log(errMsg); 
                                
                            }
                            
                            }); 
                    
                        });


                            // GET SELECTET PC AND FILL OUT EDIT FORM 
                        function thisStudentbox(clicked_id) {
                        $.ajax({
                            url:"http://10.130.16.147:57414/api/student/" + clicked_id ,
                            type: "GET",
                            dataType: "json",
                            cache: false,
                            success: function(result){
                                $("#id-edit").val(result.computerId);
                                $("#Name-edit").val(result.computerName);
                                $("#maerke-edit").val(result.brand); 
                                $("#model-edit").val(result.model); 
                                $("#status-edit").val(result.statusId); 
                                
                                
                                }
                            });
                        }


                </script>


            </div>
            <div class="footer">
                <?php include 'includes/footer.php';?>
            </div>
        </div>
    </body>
</html>