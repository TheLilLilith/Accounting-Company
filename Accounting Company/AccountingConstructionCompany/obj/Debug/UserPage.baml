   M S B A M L   `   `   `  ����X  TAccountingConstructionCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AccountingConstructionCompanyAccountingConstructionCompany  5      ,    &AccountingConstructionCompany.UserPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:AccountingConstructionCompany     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  UserPage��5
      .��5      � .+�5   
   �� $!��Личный кабинет��6   
���   �$��Open Sans Bold)�6=   $��25(�6Y   $
��Left=�6g   $	��Top=�6�   $��	10,10,0,0q�6�   $
��Bold"�6�   6�   �� 5   
   $
��Left=�6   $	��0.5q�6,   
�������$��Center=�6U   $	��300��6p   ���#f2f3f4$��	20,30,0,0q�6�    �� CornerRadius$ 	0,0,10,10��6�   ._�5      �� $��0q�6   .+�5      �� $��30��6   ���#fcd464._�5      �� $3��-Информация пользователя��6   $��Open Sans Bold)�6>   $��15(�6Z   $��DemiBold"�6h   $��Center=�6~   $��0,3,0,0q�6�   6�   5      �� 5      $��10q�6   .+�5      �� $��Имя��6   �� 5      -   5        $��UserNameBox��5       %  !MaterialDesignFloatingHintTextBox#��[  61   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   �6l   �� 5      $��Фамилия��6   �� 5      -   5        $��UserSurnameBox��5      #��[  64   
 �   �6o   �� 5      $��Отчество��6   �� 5      -   5        $��UserPatronymicBox��5      #��[  67   
 �   �6r   �� 5      $!��Номер телефона��6   �� 5      -   5        $��UserPhoneBox��5      #��[  62   
 �   �6m   �� 5      $��Email��6   �� 5       -   5        $��UserMailBox��5       #��[  61   
 �   �6l   5!      5"      5#      �� 5$   
   $��Right=�6   $	��0.5q�6.   
�������$��Center=�6W   $	��300��6r   ���#f2f3f4$��0,62,30,218q�6�   $ 	0,0,10,10��6�   $	��170��6�   ._�5%      �� $��0q�6   .+�5&      �� $��30��6   ���#fcd464._�5'      �� $��Авторизация��6   $��Open Sans Bold)�62   $��15(�6N   $��DemiBold"�6\   $��Center=�6r   $��0,3,0,0q�6�   6�   5(      �� 5)      $��10q�6   .+�5*      �� -   5        $��	UserLogin��5*        MaterialDesignFilledTextBox#��[ 5+      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��5,      
 �   �   
Foreground
 �   �5.      G� 5/      -   5        $��UserPassword��5/   "    ) %MaterialDesignFilledRevealPasswordBox#��[ 66   $ Пароль��51   "   
 �   �
 �   �$��0,10,0,0q�54   "   {�50   "   �� *	IsChecked+ �� ElementName$# RevealPasswordOutlinedEnabled��54   "   55      56      57      �� 58   
   $��Right=�6   $	��0.5q�6.   
�������$��Center=�6W   $	��300��6r   ���#f2f3f4$��
0,150,30,0q�6�   $ 	0,0,10,10��6�   ._�59      �� $��0q�6   .+�5:      �� $��30��6   ���#fcd464._�5;      �� $��Предприятие��6   $��Open Sans Bold)�62   $��15(�6N   $��DemiBold"�6\   $��Center=�6r   $��0,3,0,0q�6�   6�   5<      �� 5=      $��10q�6   .+�5>      �� -   5        $��UserCompany��5>      #��[  61   
 �   �6l   5?      5@      5A      �� 5B   
   -	   5        $��SaveDataButton��5B   E     MaterialDesignRaisedButton#��[ 6   $��Right=�6x   $��Bottom=�6�   $��Сохранить��6�   ���#fcd464
���   �$	��200��6�   $��	0,0,70,35q�6�   5C      5D      