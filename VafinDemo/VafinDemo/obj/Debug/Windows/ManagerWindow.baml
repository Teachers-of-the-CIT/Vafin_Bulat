   M S B A M L   `   `   `  ????D  @VafinDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:VafinDemo.WindowsVafinDemo.Windows  5   	   %    VafinDemo.Windows.ManagerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:VafinDemo.Windows     5   	     ? Title$  ManagerWindow??5   	   $	??450??6   $	??800??6,    ? Icon$ /Resources/icon.ico??68   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $
??130* ?6   ?? 5      $
??200* ?6   ?? 5      $
??200* ?6   ?? 5      $
??200* ?6    ? RowDefinitions 5   
   ?? 5      $	??77* ?6   ?? 5      $
??305* ?6   ?? 5      $	??52* ?6   .+?5   
   ?? -   5         ??Name$ LogoImg??5      $??/Resources/logo.png??6!   $??0??6>   $??0??6K   6]   ?? 5   
   -   5         ??Name$ ProductsBtn??5      $??Товары??6&   $??0??67   $??1??6D   $??22(?6T   $	??150??6b   $??40??6n   6?   ?? 5   
   -   5        $ ExitBtn??5      $??
Выйти??6"   $??0??62   $??3??6?   $??22(?6O   $	??150??6]   $??40??6i   6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ OrdersDataGrid??5         AutoGenerateColumns .     
IsReadOnly . $??1??6Y   $??0??6f   $??4??6v   $y?Hidden=?6?   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Дата создания??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^      FontSize$ 14Q?6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ?? *Creation_date+6x     5      $
 Дата заказа??6%   $ * 6Y   $ 14Q?6c    6:   ?? *
Order_date+6s     5      $
 Фамилия??6%   $ * 6R   $ 14Q?6\    66   ?? *	Surname+6l     5      $
 Имя??6%   $ * 6K   $ 14Q?6U    62   ?? *Name+6e     5       $
 Отчество??6%   $ * 6V   $ 14Q?6`    67   ?? *
Patronymic+6p     5!      $
 Код получения??6%   $ * 6]   $ 14Q?6g    6<   ?? *Receive_code+6w     5"      $
 Статус??6%   $ * 6P   $ 14Q?6Z    65   ?? *Status+6j   4  .System.Windows.Controls.DataGridTemplateColumn  5#      $
 auto 6)      CellTemplate 5$      ?? 5%      .R?5&      ?? $??EditOrderBtn??6j   -   5        $??Изменить??5&   %    ? ToolTip$P JПерейти к редактированию данного заказа??68   $	??100??6~   $??25??6?   $??14(?6?   6?   5'      5)      5+      ?? 5,   
   -   5        $ AddOrderBtn??5,      $??Добавить??6&   $??2??69   $??0??6F   $??4??6V   $??Center=?6j   $??Center=?6?   $	??150??6?   $??40??6?   $??22(?6?   $y?Hidden=?6?   6?   5-      5.      