   M S B A M L   `   `   `  ����
  Inform    Inform.P_MessageBox   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        ���	#FFD1FF00���	#7F000000$��1q�5   [   $	��100��5      $	��400��6,   $��0,20,0,0q�68     � 	Resources  5       �� 
TargetType   Submit_Smalllab �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity   Color �� ElementName �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6   .�5	      ��  �@J�Effect 5
        5      $ 1Q�6'   $	 0.5Q�67    6E   �� *
Background+$ C��5      �� 5       �@��CornerRadius$ 90��6-   6:   �� 5       � ��$ Right=�6/   6?   �� 5       � ��$	 Top=�62   6@   �� 5       � ��$ 2q�60   6<   �� 5       � �� 6,   �� *
Foreground+$ C��6Y   �� 5       � ��$ 25��6'   64   �� 5       � ��$ 25��6&   63   �� 5       �@��Padding$ 0q�6(   64   �� 5       � ��$ 2q�6'   63    5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � �� 63   �� *
Foreground+$ C��6`   5      5      5      .��5      ]� $
��Auto��6   ��6   �� *
Background+$ C��.+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v   �� 5    
   -   5        $��	MessImage��5       $	��100��6   $	��100��6.   $��
城市.png��6:   $
��None=�6J    J� Effect 5!        5"      $ 1Q�6N    6#   �� *
Foreground+$ C��6N   5$      �� 5%   
   $��Right=�6   .+�5&      �� -   5        #��[  5&      
���  ��._�5'      �� $��叉.png��6   6*   5(      �� 5)      -   5         ��Name$ IsPin��5)      #��[  6$   
��� � � � ToolTip$ 固定消息��6w   ._�5*      �� $��
收藏.png��6   6*   5+      5,      �� 5-   
   $��Hidden=�6   $��Disabled=�6<   .��5.      �� -   5        $��MessText��5.   &   $��15(�6   $
��Wrap=�6f   $��Center=�6z   $��10q�6�   ��66   �� *
Foreground+$ C��6�   5/      50      51      