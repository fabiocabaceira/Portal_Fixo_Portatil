<!DOCTYPE html>
<html lang="en">
<body>



<?php

require 'vendor/autoload.php';
use Carbon\Carbon;
$d = Carbon::now();

$credito = 1000;
$numPrest = 6;
$valorPrestMensal = $credito / $numPrest;

for($i= 0; $i <= $numPrest; $i++) {
$planoprestacoes[$i][0] = $d->day."-".$d->month."-".$d->year;
$planoprestacoes[$i][1] = $valorPrestMensal;
$planoprestacoes[$i][2] = $credito;
$credito = $credito / $valorPrestMensal;
}

echo "<table>
<tr>
<th> data de vencimento </th>
<th> valor da prestação mensal </th>
<th> valor em dívida </th>
</tr>";

for($i = 0; $i <= 6; $i++)
{
    echo '<td>' . $planoprestacoes[0] . '</td>';
    echo '<td>' . $planoprestacoes[1] . '</td>';
    echo '<td>' . $planoprestacoes[2] . '</td>';
}
?>


</body>
</html>