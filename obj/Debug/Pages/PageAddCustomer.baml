   M S B A M L   `   `   `  ����>  :GTS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GTS.Pages	GTS.Pages  5          GTS.Pages.PageAddCustomer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GTS.Pages     5        N� Title$  PageAddCustomer��5	       N� 
Background �#F6F6F6.��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��430 �6   .+�5   
   o� $��0��6   $��Center=�6   .@�5      m� -   5        $��
Назад��5      6&   5      �� 5   
   $	��350��6   $	��250��6    
����������#666666$��1��5      �� 5   
   $��Center=�6   $��Center=�62   $��1��5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Имя абонента:��6   $	��150��61   �� 5      -   5        $��txbName��5      $	��150��6)   $��
5, 5, 0, 5q�65   5      5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Пол:��6   $	��150��6(   �� 5      -   5        $��	cmbGender��5      $	��150��6,   $��20��68   $��
5, 5, 0, 5q�6D   .@�5      �� Мужской6)   �� 5       Женский6)   5!      5"      �� 5#      $ 
Horizontal=�6   .+�5$      �� $��Возраст:��6   $	��150��6,   �� 5%      -   5        $��txbAge��5%      $	��150��6(   $��
5, 5, 0, 5q�64   5&      5'      �� 5(      $ 
Horizontal=�6   .+�5)      �� $��Категория:��6   $	��150��6.   �� 5*      -   5        $��cmbCategory��5*      $	��150��6.   $��20��6:   $��
5, 5, 0, 5q�6F   5+      �� 5,      $ 
Horizontal=�6   .+�5-      �� $��	Долг:��6   $	��150��6)   �� 5.      -   5        $��cmbDebt��5.      $	��150��6*   $��20��66   $��
5, 5, 0, 5q�6B   .@�5/      �� 
Есть6&   �� 50      Нет6%   51      52      �� 53      $ 
Horizontal=�6   .+�54      �� $��Межгород:��6   $	��150��6-   �� 55      -   5        $��cmbIntercity��55      $	��150��6/   $��20��6;   $��
5, 5, 0, 5q�6G   .@�56      �� 
Есть6&   �� 57      Нет6%   58      59      �� 5:      -   5        $��btnSave��5:      $��Сохранить��6$      btnSave#��[  5;       � 	Resources 5<       �� 
TargetType �� Property �� Value��%^   '��       �� 5=      " ��6   .�5>      ��  �@��CornerRadius$ 7��69   5?      5@      5A      5B      5C      5D      