   M S B A M L   `   `   `  ����X  TAccountingConstructionCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AccountingConstructionCompanyAccountingConstructionCompany  5   	   .    (AccountingConstructionCompany.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:AccountingConstructionCompany     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	     � Title$  AuthorizationMenu��5	   	   $	��450��6$   $	��600��61    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6b    � WindowStyle$
 None=�6x    � AllowsTransparency . 
������  � Icon$ bin/img/helmet.ico��6�   .��5
      � -   5         � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $��2* �6   .+�5   
   �� $��2��6   $��2��6&    �� CornerRadius$ 5,5,5,5��67   ��5      �� 5       j� Stretch$
 Fill=�6   	 �� ImageSource$	 bin\img\yellowbg.png��6,   5      �� 5      -   5        $��
HideButton��5   M    "  MaterialDesignFlatAccentButton#��[  6   $��Right=�6y   
���   �$��Open Sans Bold)�6�   $��15(�6�   $��0,5,70,0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Minimize=�6*   5      �� 5      -   5        $��CloseButton��5   M   #��[  6   $��Right=�6z   
���   �$��Open Sans Bold)�6�   $��15(�6�   $��0,5,20,0q�6�   .��5        $
 Close=�6*   5      �� 5   
   $��1��6   $��1��6%   .+�5       � -   5        $��	MainFrame��5        � NavigationUIVisibility$ Hidden=�6%   6G   5       5"      5#      