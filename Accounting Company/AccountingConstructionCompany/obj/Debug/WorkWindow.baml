   M S B A M L   `   `   `  ����X  TAccountingConstructionCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AccountingConstructionCompanyAccountingConstructionCompany  5   	   .    (AccountingConstructionCompany.WorkWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   9local+clr-namespace:AccountingConstructionCompany   5   	     � Title$-  'Рабочее пространство��5	   	   $	��450��6&   $	��800��63    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ NoResize=�6e    � WindowStyle$
 None=�6{    � AllowsTransparency .  � Topmost .  
������  � Icon$ bin/img/helmet.ico��6�   .��5
      � -   5        .+�5   
   �� $��0��6   $	��162��6!   $
��Left=�6-   ���#fcd464._�5      �� -   5        $��btnMenu��5      $��	0,50,55,0q�6(   .+�5      �� -   5        $��DashBoardButton��5   [   
������ $��0q�62   
���iii�.��6�   Главная6�   �� 5      -   5        $��UserPageButton��5   {   
������ $��0q�62   
���iii�$��50��6[   $��Normal"�6g   .��5      ��  �� TextAlignment$ Center=�6    Личный�� 6>   кабинет6R   5      �� 5      -   5        $��CustomersPageButton��5   |   
������ $��0q�62   
���iii�$��50��6\   $��Normal"�6h   .��5      �� $ Center=�6    Работа с�� 6@   клиентами6V   5      �� 5      -   5        $��WarehousePageButton��5   {   
������ $��0q�62   
���iii�$��50��6[   $��Normal"�6g   .��5      �� $ Center=�6    Работа со�� 6A   складом6U   5      �� 5      -   5        $��ReportsPageButton��5   o   
������ $��0q�62   
���iii�$��Normal"�6[   .��6�   Отчеты6�   �� 5      -   5        $��CashPageButton��5   o   
������ $��0q�62   
���iii�$��Normal"�6[   .��6�   
Касса6�   �� 5      -	   5        $��GoodsPageButton��5   o   
������ $��0q�62   
���iii�$��Normal"�6[   .��6�   Товары6�   �� 5      -
   5        $��AdminPageButton��5   o   
������ $��0q�62   
���iii�$��Normal"�6[   .��6�   
Админ6�   5      5      �� 5    
   $	��684��6   ���#f2f2f8$��Right=�62    �� CornerRadius$ 	30,0,0,30��6O   	 J� Effect	 5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"      ._�5%       � -   5        $��	WorkFrame��5%      
  � NavigationUIVisibility$
 Hidden=�6%   5'      5(      �� 5)   
   -   5        $��
HideButton��5)   I    "  MaterialDesignFlatAccentButton#��[  6   $��Right=�6u   $	��Top=�6�   
���   �$��Open Sans Bold)�6�   $��15(�6�   $��0,5,70,0q�6�   .��5*      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minimize=�6&   5+      �� 5,   
   -   5        $��CloseButton��5,   I   #��[  6   $��Right=�6v   $	��Top=�6�   
���   �$��Open Sans Bold)�6�   $��15(�6�   $��0,5,20,0q�6�   .��5-        $ Close=�6&   5.      5/      50      