<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start_Page.aspx.cs" Inherits="start_page.Start_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width"/>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script> 
    <script src="Common/lib/bootstrap/js/jquery-2.1.4.js"></script>
    <link href="Common/css/bootstrap.css" rel="stylesheet" />
     <script src="Common/lib/bootstrap/js/bootstrap.js"></script>
    <link href="Common/css/menu.css" rel="stylesheet" />
    <link href="Common/css/First_look_area.css" rel="stylesheet" />
     <title>Fuffy</title>
</head>
<body>
              <div class="wrap ">
                             <nav class="navbar navbar-default navbar-inverse menu" role="navigation" >
                                 <div class="container-fluid">
                                       <div class="navbar-header">
                                          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                                      <span class="sr-only">Toggle navigation</span>
                                      <span class="icon-bar"></span>
                                      <span class="icon-bar"></span>
                                      <span class="icon-bar"></span>
                                  </button>
                                  <a class="navbar-brand" href="#">Рисунок или логотип</a>
                                       </div>

                              <!-- Collect the nav links, forms, and other content for toggling -->
                              <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                                        <ul class="nav navbar-nav">
                                            <!--<li class="active"><a href="#">Link</a></li>-->
                                          <%--  <li><a href="#"></a></li>--%>
                                            <li class="dropdown">
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Поддержка <span class="caret"></span></a>
                                                <ul class="dropdown-menu" role="menu">
                                                    <li><a href="#">Вопросы</a></li>
                                                    <li><a href="#">Связаться с нами</a></li>
                                                    <li><a href="#">Критика и предложения</a></li>
                                                    <li class="divider"></li>
                                                    <li><a href="#">Предложить фото</a></li>
                                                    <li class="divider"></li>
                                                    <li><a href="#">Смотреть популярные фотографии</a></li>
                                                </ul>
                                            </li>
                                        </ul>
                                       <!-- <form class="navbar-form navbar-left" role="search">
                                            <div class="form-group">
                                                <input type="text" class="form-control" placeholder="Search">
                                            </div>
                                            <button type="submit" class="btn btn-default">Submit</button>
                                        </form>-->
                                  <!--Тулбар для поиска - код тот, что сверху -->

                                        <ul class="nav navbar-nav navbar-right">
                                           <%-- <li>
                                                <p class="navbar-text"><a href="#" style="color:#FAEBD7">Регистрация</a></p>
                                            </li>--%>
                                            <li class="dropdown">
                                                <a href="#" class="dropdown-toggle " data-toggle="dropdown"><b>Войти</b> <span class="caret"></span></a>
                                                <ul id="login-dp" class="dropdown-menu">
                                                    <li>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                Войти
                                                                <div class="social-buttons">
                                                                    <a href="#" class="btn btn-fb"><i class="fa fa-facebook"></i> Facebook</a>
                                                                    <a href="#" class="btn btn-tw"><i class="fa fa-twitter"></i> Twitter</a>
                                                                </div>
                                    
                                                                <form class="form" role="form" method="post" action="login" accept-charset="UTF-8" id="login-nav">
                                                                    <div class="form-group">
                                                                        <label class="sr-only" for="exampleInputEmail2">Email</label>
                                                                        <input type="email" class="form-control" id="exampleInputEmail2" placeholder="Почта" required="required"/>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="sr-only" for="exampleInputPassword2">Password</label>
                                                                        <input type="password" class="form-control" id="exampleInputPassword2" placeholder="Пароль" required="required"/>
                                                                        <div class="help-block text-right"><a href="#">Забыли пароль?</a></div>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <button type="submit" class="btn btn-primary btn-block">Войти</button>
                                                                    </div>
                                                                    <div class="checkbox">
                                                                        <label>
                                                                            <input type="checkbox"/> оставться в сети
                                                                        </label>
                                                                    </div>
                                                                </form>
                                                            </div>
                                                            <div class="bottom text-center">
                                                               Впервые здесь? <a href="#"><b>Зарегестрироваться</b></a>
                                                            </div>
                                                        </div>
                                                    </li>
                                                </ul>

                                            </li>
                                        </ul>

                                            </div>
                                 </div>
                             </nav>

              <%--    Здесь начинается слайдер--%>


                   <div id="carousel" class="carousel slide" >
                        <ol class="carousel-indicators">
                            <li class="active" data-target="#i-carousel" data-slide-to="0"></li> <!-- для включения прокрутки здесь в классе active вставить букву e-->
                            <li data-target="#carousel" data-slide-to="1"></li>
                            <li data-target="#carousel" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner"  >
                            <div class="item active">
                               <img  src="Common/images/11a.jpg" />
                                <div class="carousel-caption">
                                    <h3>Улови красоту</h3>
                                    <p></p>
                                </div>
                            </div>
                            <div class="item">
                            <img src="Common/images/11b.jpg" />
                                <div class="carousel-caption">
                                    <h3> Запечатли закат</h3>
                                    <p> </p>
                                </div>
                            </div>
                            <div class="item">
                                <img  src="Common/images/11a.jpg" />
                                <div class="carousel-caption">
                                    <h3>Создай шедевр</h3>
                                    <p></p>
                                </div>
                            </div>
                        </div>
        

                        <a href="#carousel" class="left carousel-control" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left" ></span>
                        </a>
                        <a href="#carousel" class="right carousel-control" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right" ></span>
                        </a>
                    </div>

          <div class="white">
                <img class="img-responsive" src="Common/images/Fuffy.png" />


                </div>



              </div>
              <div class="medium-part container-fluid">
                   <h2>Крупнейшее сообщество для профессиональных фотографов и любителей, дизайнеров, стилистов и просто креативных людей, ищущих вдохновение</h2>
                        <div class="t container-fluid">                
                                      <div class="metka row" >
                                              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 photo-of-day" style=" padding: 0px; padding-bottom: 5px;">
                                                    <h5 style="color: white; text-align: center;">Фото дня</h5> 
                                            <img class="photo-of-day col-lg-12 col-md-12 col-sm-12 col-xs-12" src="Common/images/best.jpg" />
                                         
                                                </div>
                                                     <div class=" col-lg-6 col-md-6 col-sm-6 col-xs-6 photo-for-score" >
                                                          <h5 style="color: white; text-align: center; padding: 10px;">Ждут критики</h5>
                                                                 <div class=" photo-for-score-container container-fluid">
                                                                           <div class="row">
                                                                                <img class=" imag col-lg-3 col-md-3 col-sm-2 col-xs-2" src="Common/images/look.com.ua-71249.jpg" />
                                                                                <img class=" imag col-lg-3 col-md-3 col-sm-2 col-xs-2" src="Common/images/best.jpg" />
                                                                                <img class=" imag col-lg-3 col-md-3 col-sm-2 col-xs-2" src="Common/images/11a.jpg" />
                                                                                <img class=" imag col-lg-3 col-md-3 col-sm-2 col-xs-2" src="Common/images/1.jpg" />
                                                                            </div>
                                                                           <div class="row">
                                                                                <img class="imag col-lg-3col-md-3 col-sm-2 col-xs-2" src="Common/images/7.jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2" src="Common/images/best.jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2" src="Common/images/3287x2183_537145_[www.ArtFile.ru].jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2" src="Common/images/look.com.ua-71249.jpg" />
                                                                            </div>
                                                                           <div class="row">
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2"   src="Common/images/best.jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2"  src="Common/images/3287x2183_537145_[www.ArtFile.ru].jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2"  src="Common/images/1.jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2"  src="Common/images/look.com.ua-71249.jpg" />
                                                                            </div>
                                                                           <div class="row">
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2"  src="Common/images/17.jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2"  src="Common/images/11a.jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2"  src="Common/images/7.jpg" />
                                                                                <img class="imag col-lg-3 col-md-3 col-sm-2 col-xs-2" src="Common/images/look.com.ua-71249.jpg" />
                                                                              </div>
                                                                 </div>
                                                     </div>
                                      </div>
                        </div>
              </div>

        
    
  <%--  <footer >

        </footer>--%>
</body>
     
</html>
