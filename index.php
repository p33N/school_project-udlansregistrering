<?php

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
        <link rel="stylesheet" href="style/productstylesheets.css">
        <link rel="stylesheet" href="style/studentstylesheets.css">

        <!--- LINKS --->
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

                <form  id="ticket-form">
                    <label for="student_name">Elev nummer:</label><br>
                        <input type="text" id="id" name="studentId" ><br>
                    <label for="computer_ID">Computer ID:</label><br>
                        <input type="text" id="PcId" name="computerId" ><br>
                    <label for="cars">Vælg en mus:</label>
                    
                    <select name="mus" id="mus" name="mouseId" > 
                        <option value="0">ingen</option>
                        <option value="1">optisk</option>
                        <option value="2">trådløs</option>
                    </select>
                    
                    <label for="cars">Vælg et tastatur:</label>
                    
                    <select name="tastatur" id="tastatur" name="keyboardId">
                        <option value="0">ingen</option>
                        <option value="1">trådet</option>
                        <option value="2">trådløs</option>
                        <option value="3">mekanisk</option>
                    </select><br>
                    
                    <label for="start_date">Start dato:</label>
                        <input type="date" id="datepicker-start" name="borrowDate"><br>
                    <label for="end_date">Slut dato:</label>
                        <input type="date" id="datepicker-slut" name="expirationDate"><br>
                        <input type="hidden" value="0" name="returned">
                        <button id="create" >Opret</button>             


                </form> 

                <div class="scrollbox">
                    <table id="productstable">
                        <tr>
                            <th>Computere</th>
                        </tr>
                            <script> 
                                // GET ALL PC'S 
                                $.ajax({
                                url:"http://10.130.16.147:57414/api/computer",
                                type: "GET",
                                dataType: "json",
                                cache: false,
                                success: function(result){
                                    result.forEach(element => {
                                        $("#productstable").append("<tr> <td class='pcbox' id='"+element.computerId+"' onclick='thispcbox(this.id)' > " + element.computerName + " </td> </tr> ");
                                        });
                                    }
                                });
                                
                            </script>
                    </table>
                </div>
                
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
                            
                            var myData = $("#ticket-form").serializeObject(); 
                            event.preventDefault();
                            $.ajax({
                            type: "POST",
                            url:"http://10.130.16.147:57414/api/ticket",
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            data:  JSON.stringify(myData) ,
                            contentType: "application/json",
                            dataType: "json",
                            success: function(result){
                                alert("ticket oprettet")
                            },
                            error: function (errMsg) {
                                console.log(errMsg); 
                            }
                            }); 
                    
                        }); 




                function thisStudentbox(clicked_id) {
                    $.ajax({
                            url:"http://10.130.16.147:57414/api/student/" + clicked_id ,
                            type: "GET",
                            dataType: "json",
                            cache: false,
                            success: function(result){
                                $("#id").val(result.studentId);
                                
                                }
                            });
                }

                function thispcbox(clicked_id) {
                    
                    $.ajax({
                                url:"http://10.130.16.147:57414/api/computer/" + clicked_id ,
                                type: "GET",
                                dataType: "json",
                                cache: false,
                                success: function(result){
                                    $("#PcId").val(result.computerId);
                                
                                    
                                  
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