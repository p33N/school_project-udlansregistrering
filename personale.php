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
                    <img src="images/headerimage.png" alt="Banner" height="100%" width="100%">
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
                    <label for="name">Unilogin:</label><br>
                    <input type="text" id="number" name="number" ><br>
                    <label for="name">Navn:</label><br>
                    <input type="text" id="Navn" name="id" ><br>
                    <label for="adress">Adresse:</label><br>
                    <input type="text" id="Adresse" name="Adresse" ><br>
                    <label for="zipcode">Postnummer:</label><br>
                    <input type="text" id="zipcode" name="zipcode" ><br>
                    <label for="cpr">CPR Nummer:</label><br>
                    <input type="text" id="cpr" name="cpr" ><br>
                    <label for="email">Email:</label><br>
                    <input type="text" id="email" name="email" ><br>
                    <label for="class">Klasse:</label><br>
                    <input type="text" id="class" name="class" ><br>
                    <input type="submit" id="btn-ret" value="Ændre">
                    <input type="submit" id="btn-slet" value="Slet">
                </form> 

                <form id="studentform">
                    
                    <input type="hidden" id="id-edit">

                    <label for="studentNumber">Unilogin:</label><br>
                    <input type="text" id="studentNumber" name="studentNumber" ><br>

                    <label for="studentName">Navn:</label><br>
                    <input type="text" id="studentName" name="studentName" ><br>

                    <label for="address">Adresse:</label><br>
                    <input type="text" id="address" name="address" ><br>

                    <label for="zipCity">Postnummer:</label><br>
                    <input type="text" id="zipCity" name="zipCity" ><br>

                    <label for="socialSecurity">CPR Nummer:</label><br>
                    <input type="text" id="socialSecurity" name="socialSecurity" ><br>
                    
                    <label for="email">Email:</label><br>
                    <input type="text" id="email" name="email" ><br>
                    
                    <label for="class">Klasse:</label><br>
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
                                $("#id-edit").val(result.studentId);

                                $("#number").val(result.studentNumber);
                                $("#Navn").val(result.studentName);
                                $("#Adresse").val(result.address); 
                                $("#zipcode").val(result.zipCity); 
                                $("#cpr").val(result.socialSecurity); 
                                $("#email").val(result.email); 
                                $("#class").val(result.class); 
                                
                                }
                            });
                        }

                        // UPDATE PC 
                        $("#btn-ret").click(function () {

                            event.preventDefault();

                        var NumberVal = $("#number").val(); 
                        var NameVal = $("#Navn").val(); 
                        var AdresseVal = $("#Adresse").val(); 
                        var zipcodeVal = $("#zipcode").val(); 
                        var cprVal = $("#cpr").val(); 
                        var emailVal = $("#email").val(); 
                        var classVal = $("#class").val(); 

                        $(this).closest('form').find("input[type=text], textarea").val("");
                        var myData = [{"op":"replace",
                                        "path":"studentNumber",
                                        "value": NumberVal
                                        },
                                        {"op":"replace",
                                        "path":"studentName",
                                        "value": NameVal
                                        },
                                        {"op":"replace",
                                        "path":"address",
                                        "value": AdresseVal
                                        },
                                        {"op":"replace",
                                        "path":"zipCity",
                                        "value": zipcodeVal
                                        },
                                        {"op":"replace",
                                        "path":"socialSecurity",
                                        "value": cprVal
                                        },
                                        {"op":"replace",
                                        "path":"email",
                                        "value": emailVal
                                        },
                                        {"op":"replace",
                                        "path":"class",
                                        "value": classVal
                                        }
                                    ]

                        $.ajax({
                            url:"http://10.130.16.147:57414/api/student/" + $("#id-edit").val() ,
                            type: "Patch",
                            dataType: "json",
                            headers: {
                            'Content-Type': 'application/json'
                            },
                            contentType: "application/json",

                            data:  JSON.stringify(myData) ,

                            cache: false,
                            success: function(result){
                                alert("all done"); 
                                }
                            });
                        })


                          // DELETE PC
                          $("#btn-slet").click(function () {
                            event.preventDefault();
                            $(this).closest('form').find("input[type=text], textarea").val("");

                            $.ajax({
                                url:"http://10.130.16.147:57414/api/student/" + $("#id-edit").val() ,
                                type: "Delete",
                                dataType: "json",
                                headers: {
                                'Content-Type': 'application/json'
                                },
                                contentType: "application/json",
                                cache: false,
                                success: function(result){

                                    alert("student is gone ")

                                    $("#id-edit").val("");
                                    $("#number").val("");
                                    $("#Navn").val("");
                                    $("#Adresse").val(""); 
                                    $("#zipcode").val(""); 
                                    $("#cpr").val(""); 
                                    $("#email").val(""); 
                                    $("#class").val(""); 
                                    }
                                });

                        })

                </script>


            </div>
            <div class="footer">
                <?php include 'includes/footer.php';?>
            </div>
        </div>
    </body>
</html>