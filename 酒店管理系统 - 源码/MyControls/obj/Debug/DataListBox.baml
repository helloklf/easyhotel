   M S B A M L   `   `   `  ����E  AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MyControls
MyControls  5          MyControls.DataListBox   5      myclr-namespace:MyControls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value �� 
TargetType ��Name	 �� Padding
 �� TextAlignment A� Columns��%�  '��       '�� �     '�� �    'm�     �� 5	   
   " ��6   .�5
      ��  � |� .  6:   �� 5       � ��$ 0q�60   6<   �� 5       � �� 6+   Z� 6>   �� 5       � ��$ Hidden=�6I   6Z   �� 5       � ��$ Disabled=�6K   6^   5      �� 5   
   " ��6    5      P� 5       �@��
IsSelected . . �5      ��  � ��
 �  ��6A   5      P� 5       �@��
IsSelected .  . �5      ��  � ��
 � � �6C   5      5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5       �� $ Border��6!   ���#9000._�5!      ]� .+�5"   "   �� $	��Top=�6,   $	 5q�6A   $��18(�6M   ���#FFF
���   �右键菜单6�   �� 5#   "   $��Bottom=�6,   $
 Right=�6D   $	 3q�6Z   $��11(�6f   
����������	#4C000000房管子预览版6�   �� 5$   "   $��5q�61   5%      5&      5'      5)      �� 5*       � �� 5+      �� 5,      .R�5-      A� $ 2��6&   64   5.      50      51      �� 53   
   " m�6   .�54      ��  � �� 55      �� 56      " m�6&   .R�57      �� $��Header��6+   $��Center=�6B   $��Center=�6_   58      5:      5;      5<      .��5=      �� -   5         ��Name$ LB��5=   *    �� SelectedValuePath$ ALevelID��66    � ContextMenu 5>   
   �� 5?      
�������.@�5@      m� ��5A         MyControls.AddItemBtn  5B         MyControls.AddItemBtn   MouseLeftButtonDown$ AddItem��6@   $	��130��6(   $��60��64   6`   5D      m� 5E      ��5F         MyControls.Edit  5G         MyControls.Edit   MouseLeftButtonDown$ EditItem��6:   $	��130��6"   $��60��6.   6[   5I      m� 5J      -   5         m�Name$ MenuItemEmable��5J      ��5K         MyControls.RestoreBtn  5L         MyControls.RestoreBtn   MouseLeftButtonDown$ SelectedItemEnabled��6@   $	��130��6(   $��60��64   6l   5N      m� 5O      -   5        $ MenuItemForbidden��5O      ��5P         MyControls.DeleteBtn  5Q         MyControls.DeleteBtn   MouseLeftButtonDown$ SelectedItemEnabledNo��6?   $	��130��6'   $��60��63   6m   5S      5T      ��5V   
   �� 5W      .R�5X      � 6   5Y      5u      5v      