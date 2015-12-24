var left=0;
var right=0;
var like=0;
var yhl=0;
var width = window.width;
$('#hide-profile').click(function(){

	$('.content-cell-flank-left').hide();
	$('.col-sm-9').removeClass('col-sm-9').addClass('col-sm-12');
	if (right!=0){
		$('.col-md-9').removeClass('col-md-9').addClass('col-md-12');
	}
	if (right==0){
		$('.col-md-6').removeClass('col-md-6').addClass('col-md-9');
	}
	left=1;
})
$('#hide-albums').click(function(){
	$('.content-cell-flank-right').hide();
	if (left==1){
		$('.col-md-9').removeClass('col-md-9').addClass('col-md-12');
		
	}
	if (left==0){
		$('.col-md-6').removeClass('col-md-6').addClass('col-md-9');
	}
	right=1;
})
$('#profile').click(function(){
	$('.content-cell-flank-left').show();
	$('.col-sm-12').removeClass('col-sm-12').addClass('col-sm-9');
	if (left==1 && right==1){
		$('.col-md-12').removeClass('col-md-12').addClass('col-md-9');
	}
	if (left==1 && right==0)
	{
	    $('.col-md-9').removeClass('col-md-9').addClass('col-md-6');
	}
	if (left==0 && right==1)
	{
	    $('.col-md-9').removeClass('col-md-9').addClass('col-md-6');
	}
	left=0;

})
$('#albums').click(function(){
	$('.content-cell-flank-right').show();
	if (left==1 && right==1){
		$('.col-md-12').removeClass('col-md-12').addClass('col-md-9');
	}
	if (left==0 && right==1)
	{
		$('.col-md-9').removeClass('col-md-9').addClass('col-md-6');
	}
	right=0;
})

function counter(){
	if(yhl==0){
		like=like+1;
		$('.like').text(like);
	}
	yhl=1;
}