   M S B A M L   `   `   `  ????D  @VafinDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:VafinDemo	VafinDemo  5   	   "    VafinDemo.AutorizationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:VafinDemo     5   	     ? Title$  AutorizationWindow??5   	   $	??300??6$   $	??250??61    ? Icon$ /Resources/icon.ico??6=   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      6   ?? 5      6   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      $	??20* ?6   6-   ?? 5      $	??63* ?6   6-   .+?5   
   ?? $??0??6   $??Center=?6!   $??Center=?6>   $??22??6Y   $??48??6f   
Логин6x   ?? 5   
   -   5         ??Name$ LoginTb??5      $??0??6#   $??1??60   $??30??6@   ?? 5   
   $??1??6   $??Center=?6!   $??Center=?6?   $??30??6Z   Пароль6n   ?? 5   
   -   5        $ 
PasswordTb??5      $??1??6&    K? ZIndex$ 1??63   $??1??6D   $??30??6T   ?? 5   
   -   5         ??Name$ AuthorizationBtn??5      $??2??6+   $??3??68   $??Center=?6L   $??Center=?6g   ???#A5E887
???????$??
Войти??6?   $	??150??6?   $??40??6?   6?   5      5      