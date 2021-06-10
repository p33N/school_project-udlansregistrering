<?php 
    include 'includes/header.php'; 
?>
 
            <div class="content">

        <!--- LINKS --->
        <link href="https://fonts.googleapis.com/css2?family=Odibee+Sans&display=swap" rel="stylesheet">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    </head>

                    
                    
                    <?php include 'includes/navbar.php';?>
                
                </div>
            </div>
            <div class="content">
            
            <form  id="studentform-edit">
                    <label for="student_name">Elev nummer:</label><br>
                    <input type="text" id="id" name="student number" ><br>
                    <label for="computer_ID">Computer ID:</label><br>
                    <input type="text" id="maerke" name="computer ID" ><br>
                    <label for="cars">Vælg en mus:</label>
                        <select name="mus" id="mus">
                            <option value="ingen">ingen</option>
                            <option value="optisk">optisk</option>
                            <option value="wireless">trådløs</option>
                        </select>
                    <label for="cars">Vælg et tastatur:</label>
                        <select name="tastatur" id="tastatur">
                            <option value="ingen">ingen</option>
                            <option value="trådet">trådet</option>
                            <option value="trådløs">trådløs</option>
                            <option value="mekanisk">mekanisk</option>
                        </select><br>
                    <label for="start_date">Start dato:</label>
                    <input type="date" id="datepicker"><br>
                    <label for="end_date">Slut dato:</label>
                    <input type="date" id="datepicker"><br>
                    <input type="submit" id="btn-ret" value="Ændre">
                    <input type="submit" id="btn-slet" value="Slet">
                </form> 
            
                <script>
                $("#btn-ret").click(function(){
                
                alert("ændringerne er gemt"); 
                })

                </script>
            </div>
            <div class="footer">
                <?php include 'includes/footer.php';?>
            </div>
        </div>
    </body>
</html>

