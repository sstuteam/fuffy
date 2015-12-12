var left=0;
var right=0;
function hideLeftDiv(){
	$('.content-cell-flank-left').hide();
	$('.col-xs-6').removeClass('col-xs-6').addClass('col-xs-9');
	if (right!=0){
		$('.col-xs-9').removeClass('col-xs-9').addClass('col-xs-12');
	}
	left=1;
}
function hideRightDiv(){
	$('.content-cell-flank-right').hide();
	$('.col-xs-6').removeClass('col-xs-6').addClass('col-xs-9');
	if (left!=0){
		$('.col-xs-9').removeClass('col-xs-9').addClass('col-xs-12');
	}
	right=1;
}
function showLeftDiv(){
	$('.content-cell-flank-left').show();
	if (left==1 && right==1){
		$('.col-xs-12').removeClass('col-xs-12').addClass('col-xs-9');
	}
	if (left==1 && right==0)
	{
		$('.col-xs-9').removeClass('col-xs-9').addClass('col-xs-6');
	}
	left=0;

}
function showRightDiv(){
	$('.content-cell-flank-right').show();
	if (left==1 && right==1){
		$('.col-xs-12').removeClass('col-xs-12').addClass('col-xs-9');
	}
	if (left==0 && right==1)
	{
		$('.col-xs-9').removeClass('col-xs-9').addClass('col-xs-6');
	}
	right=0;

}