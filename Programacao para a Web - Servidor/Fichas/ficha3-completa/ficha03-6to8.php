<!DOCTYPE html>
<html lang="en">
<link rel="stylesheet" type="text/css" href="tabela.css">
<body>



<?php


require '../FICHA3-c/autoload.php';
use Carbon\Carbon;
$d = Carbon::now();


$credito = 1000;
$numPrest = 6;
$valorPrestMensal = $credito / $numPrest;
$datainicial=strtotime($d);

for($i= 0; $i <= $numPrest; $i++) {
$planoprestacoes[$i][0] = $i;
$planoprestacoes[$i][1] = $d->day."-".$d->month."-".$d->year;
$planoprestacoes[$i][2] = round($valorPrestMensal,2);
$planoprestacoes[$i][3] = round($credito,2);
$credito = $credito - $valorPrestMensal;
$d->addMonth();
}

echo "<table>

<tr>
<th> Numero da prestacao </th>
<th> data de vencimento </th>
<th> valor da prestação mensal </th>
<th> valor em dívida </th>
</tr>";


for($b=1; $b <= $numPrest; $b++ ) {
    echo "<tr>";
    for ($c = 0; $c <= 3; $c++) {
        echo '<td>' . $planoprestacoes[$b][$c] . '</td>';

    }
    echo "</tr>";
}

echo "<table/>"
?>


</body>


</html>