<!DOCTYPE html>
<html lang="en">

    <style>
        .centro{
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            text-align: center;
            min-height: 100vh;
            background-color: coral;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 160px;
        }
    </style>
<body>

<?php

$nr1 = $_GET["num01"];
$nr2 = $_GET["num02"];
$oper = $_GET["oper"];


function calcular($nr1, $nr2, $oper) {
    $resultado;
    switch ($oper) {
        case "soma":
            $resultado = $nr1 + $nr2;
            break;
        case "sub":
            $resultado = $nr1 - $nr2;
            break;
        case "div":
            $resultado = $nr1 / $nr2;
            break;
        case "mul":
            $resultado = $nr1 * $nr2;
            break;
        default:
            $resultado = "Error 69: buggaste isto manobro";
                break;
    }
    return $resultado;
}


$texto =  calcular($nr1, $nr2, $oper);

?>

<div class="centro">
<?php

echo " O teu resultado é: $texto";

?>
</div>
</body>
</html>

