   M S B A M L   `   `   `  ����E  AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MyControls
MyControls  5          MyControls.DataListMenu   5      myclr-namespace:MyControls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$
  this��5   0   ��5      �� *	ForeColor+��60   �� *	BgColor+ � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName��%�  '��       �� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $��37��6!   $��90��6-   ._�5      �� $ 
Horizontal=�6)   .+�5   "   �� $	 IsC��6(   $��Image/未选中.png��65   6N   �� 5   "   $��	回收站��6,   $��Center=�67   $��Center=�6T   $��15(�6o   6   5      5       5      P� 5      	 �@d�	IsChecked$

 TrueY�6;   . �5   "   �� $	 IsC��6)    � ��$ Image/选中.png��6R   6i   5      P� 5      	 �@d�	IsChecked$
 falseY�6;   . �5   "   �� $	 IsC��6)    � ��$ Image/未选中.png��6R   6j   5      5      5      5       5!      .��5"      �� $ 
Horizontal=�6   $
��10,5q�6*   .+�5#   
   �� $��2q�6D    �� Padding$ 0q�6O   ��6   �� *
Background+ �� ElementName$
 this��._�5$      �� -   5         ��Name$ IsCheck��5$   U   $��5q�6   ��6"   �� *
Foreground+$
 this��6   5%         MyControls.AddItemBtn  5&   
      MyControls.AddItemBtn   	MouseDown$ AddItem��6$   $��50��6   6:      MyControls.Edit  5'   
      MyControls.Edit   	MouseDown$ EditItem��6   $��50��6   65      MyControls.RestoreBtn  5(   
      MyControls.RestoreBtn   	MouseDown$ SelectedItemEnabled��6$   $��50��6   6F      MyControls.DeleteBtn  5)   
      MyControls.DeleteBtn   	MouseDown$ SelectedItemEnabledNo��6#   $��50��6   6G   5*      5+      