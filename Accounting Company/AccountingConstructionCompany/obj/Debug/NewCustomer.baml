   M S B A M L   `   `   `  ����X  TAccountingConstructionCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AccountingConstructionCompanyAccountingConstructionCompany  5   	   /    )AccountingConstructionCompany.NewCustomer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:AccountingConstructionCompany     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        � Title$  Новый клиент��5	   	   $��436.543��6   $��349.137��6/    � WindowStartupLocation$ CenterScreen=�6?    � 
ResizeMode$ NoResize=�6d    � WindowStyle$
 None=�6z    � AllowsTransparency . 
������  � ShowInTaskbar .  � Topmost .  � Icon$ bin/img/helmet.ico��6�   .��5
      � -   5         � RowDefinitions 5   
   �� 5      $	��46* �6   �� 5      $
��160* �6   �� 5      $
��167* �6   �� 5      $	��64* �6   .+�5   
   �� 
�������$��4��6$   	 �� CornerRadius$	 	0,0,10,10��65   �� 5   
   
���   �._�5      � .+�5      �� -   5        $��
HideButton��5   Q    "  MaterialDesignFlatAccentButton#��[  6   $��Right=�6}   
�������$��Open Sans Bold)�6�   $��15(�6�   $��0,0,60,0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Minimize=�6.   5      �� 5      -   5        $��CloseButton��5   Q   #��[  6   $��Right=�6~   
�������$��Open Sans Bold)�6�   $��15(�6�   $��0,0,10,0q�6�   .��5        $
 Close=�6.   5      5      5      �� 5   
   $��1��6   .+�5      �� $��bin/img/add.png��6   $��UniformToFill=�6.   $	��100��6F   $	��100��6S   �� 5      $��Новый клиент��6   
���   �$��Open Sans Bold)�6@   $��25(�6\   $��Center=�6j   $��0,10,0,0q�6�   $
��Bold"�6�   6�   5       � 5!   
   $��2��6   $��2��6!   .+�5"      �� .+�5#      �� -   5         ��Name$ cNameBox��5#      $��	10,10,0,0q�6,   $	��160��6?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя��6L     MaterialDesignFilledTextBox#��[ 5$      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   �   
Foreground
 �   ���5%      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5'      �� 5(      -   5        $ cSurnameBox��5(      $��	10,10,0,0q�6/   $	��160��6B   $ Фамилия��6N   #��[ 5)      
 �   �
 �   ���5*      �� *Name+$ PropertyChanged=�5,      �� 5-      -   5        $ cPatronymicBox��5-      $��	10,10,0,0q�62   $	��160��6E   $ Отчество��6Q   #��[ 5.      
 �   �
 �   ���5/      �� *Name+$ PropertyChanged=�51      52      �� 53      .+�54      �� -   5        $ cMailBox��54      $��	10,10,0,0q�6,   $	��160��6?   $ 
Почта��6K   #��[ 55      
 �   �
 �   ���56      �� *Name+$ PropertyChanged=�58      �� 59      -   5        $ 	cPhoneBox��59      $��	10,10,0,0q�6-   $	��160��6@   $ Телефон��6L   #��[ 5:      
 �   �
 �   ���5;      �� *Name+$ PropertyChanged=�5=      �� 5?      -	   5        $ 
cAdressBox��5?      $��	10,10,0,0q�6.   $	��160��6A   $ 
Адрес��6M   #��[ 5@      
 �   �
 �   ���5A      �� *Name+$ PropertyChanged=�5C      5D      5E      � 5F   
   $��3��6   $��10q�6!   .+�5H      �� -
   5        $��
BackButton��5H   R   $��
Назад��6   
���   �
������ $��0,0,0,0q�6~   $	��150��6�   $��0q�6�   �� 5J      -   5        $��AddClientButton��5J   I     MaterialDesignRaisedButton#��[ 6   $��Добавить��6�   
���   �
�������$��10,0,0,0q�6�   $	��150��6�   5K      5M      5N      