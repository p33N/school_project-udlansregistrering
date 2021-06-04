<?php 
    include 'includes/header.php'; 
?>
 
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
        
<?php
    include 'includes/footer.php';
?>