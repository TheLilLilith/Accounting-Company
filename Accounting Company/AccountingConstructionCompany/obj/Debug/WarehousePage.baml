   M S B A M L   `   `   `  ����X  TAccountingConstructionCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AccountingConstructionCompanyAccountingConstructionCompany  5      1    +AccountingConstructionCompany.WarehousePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:AccountingConstructionCompany     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  WarehousePage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      $	��67* �6   .+�5   
   �� $��0��6   $��
Склад��6   
���   �$��Open Sans Bold)�6A   $��25(�6]   $
��Left=�6k   $	��Top=�6�   $��	10,10,0,0q�6�   $
��Bold"�6�   6�   �� 5   
   
�������$��1��6$   $
��Left=�61   $��Bottom=�6L   $	��220��6g   $	��390��6s    �� CornerRadius$ 	0,20,0,20��6�   ._�5      �� .+�5      �� $��
Товар��6   
���   �$��Open Sans Bold)�6<   $��25(�6X   $
��Left=�6f   $	��Top=�6�   $��	10,10,0,0q�6�   $
��Bold"�6�   6�   �� 5      -   5        $��ProductNameTextBox��5      $��
20,10,20,0q�64   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Наименование��6H    !  MaterialDesignOutlinedTextBox#��[  5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   �   
Foreground
 �   �   
Background
 �����   FloatingScale$	 0.9Q�5      ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      -   5        $��ProductQuantityTextBox��5      $��
20,10,20,0q�68   $ Количество��6L   #��[  5       
 �   �
 �   �
 �����$	 0.9Q�5%      ��5!      �� *Name+$ PropertyChanged=�5%      �� 5&      -   5        $��ProductPriceTextBox��5&      $��
20,10,20,0q�65   $ Цена��6I   #��[  5'      
 �   �
 �   �
 �����$	 0.9Q�5,      ��5(      �� *Name+$ PropertyChanged=�5,      � 5-      $��Center=�6   $��20q�69   .+�5.      �� -   5        $��DeleteButton��5.   V    " MaterialDesignFlatAccentButton#��[ 6   
���   �$��Open Sans Bold)�6�   $��15(�6�   $��0,0,0,0q�6�   $��42��6�   $��65��6�   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Delete=�62   $��32��6@   $��32��6L   
 � ToolTip
 50      �� 51      Удалить товар67   53      �� 54      -   5        $��
EditButton��54   V   #��[ 6   
���   �$��Open Sans Bold)�6�   $��15(�6�   $��0,0,0,0q�6�   $��42��6�   $��65��6�   .��55        $	 Pencil=�62   $��32��6@   $��32��6L   
 56      �� 57      '%Редактировать товар6=   59      5:      5;      5=      �� 5>   
   $��1��6   $	��390��6   $	��450��6+   $ 20,0,0,0��67   $��Bottom=�6O   $��Right=�6j   
�������._�5?      �� -   5        $��InventoryListView��5?   r   $��Disabled=�6   $��Center=�6N   $��	10,10,0,0q�6�   ��6�   ��  �� Path$ Table���5@      �� 5A      .R�5B      � $��	10,10,0,0q�6$   5C      ��5E      �� 5F      .R�5G      �� $ 10��6!   $	��0.5q�64   
�������$	��190��6^   $��80��6j   ��5H      �� 5I   "    �� EndPoint$ 0.4,0&�66    �� 
StartPoint$ 0.2,2&�6G   .��5J   &   �  � Color$ White��63    � Offset$ 0.554Q�6A   � 5K   &   $ #fcd464��63   $	 0.5Q�6C   5L   #   ._�5O      � $��	10,10,0,0q�6#   .+�5P   "   �� $	��180��6-   .+�5Q   &   �� $��DemiBold"�6V   $��15(�6l   ��61   �� $ ProductName�6|   � 5R   &   .+�5S   *   �� $��Количество: ��64   6J   �� 5T   *   $��DemiBold"�6U   ��64   �� $ Quantity�6m   5U   '   � 5V   &   .+�5W   *   �� $��Open Sans Bold)�6R   $
��Bold"�6n   $��18(�6�   ��64   �� $ Price�6�   �� 5X   *   $�� руб./шт. ��64   $��Open Sans Bold)�6F   $
��Bold"�6b   $��18(�6t   6�   5Y   '   5[   #   5]      5^      5_      5a      5b      5c      5d      