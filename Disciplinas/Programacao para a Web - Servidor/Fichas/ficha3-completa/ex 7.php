<!DOCTYPE html>
<html lang="en">

<body>


<?php //Aqui requirimos o ficheiro autoloa.php que nos deixa usar o Carbon
require '../vendor/autoload.php';
use Carbon\Carbon;
// declarar a variavél d que retorna a data e hora atual
$d = Carbon::now();
?>

<?php
// Declarar a variavél credito e a varivael numero de prestações
$credito = 1000;
$numPrest = 6;

// Declarar a variavél valor prestação mensal ou seja o valor que o cliente tem que pagar mensalmente
$valorPrestMensal = $credito / $numPrest;

//strtotime: The function expects to be given a string containing an English date format and will try to parse that format into a Unix timestamp
$datainicial = strtotime($d);

//Iniciar o array planoprestações
$planoprestacoes = array();

//Loop for para o preencher
    for($i=0; $i<$numPrest; $i++){
        $planoprestacoes[$i] = array($i. "-", $d->day. "-".$d->month. "-".$d->year, $valorPrestMensal, $credito - ($valorPrestMensal * $i));
        $d->addMonth();
    }

echo "<table>

<tr>
<th> Numero da prestacao </th>
<th> data de vencimento </th>
<th> valor da prestação mensal </th>
<th> valor em dívida </th>
</tr>";


for($b=1; $b<$numPrest; $b++ ) {
    foreach($planoprestacoes as $value) {

        for ($c = 0; $c <= 3; $c++) {

            echo '<td>' .  $planoprestacoes[$b][$c] .  '</td>';
        }
            }

    echo "</tr>";
}

echo "<table/>"
?>




</body>


</html>