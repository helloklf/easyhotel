   M S B A M L   `   `   `  ����A  =Inform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Project_Term2Project_Term2  5   L       Inform.W_Message   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   (myclr-namespace:Project_Term2    6L   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  
MainColors��5   .    �� InputLanguage$ EN-US��5   $    � WindowStartupLocation$ CenterScreen=�5   	   $��1q�5   i    � Title$ 消息��5   	   $	��240��6   $	��320��6!    � AllowsTransparency .  � WindowStyle$
 None=�6G    � WindowState$ Normal=�6Z   ��5   	   �� *
Foreground+ �� ElementName$ C����69   �� *
Background+$ C����6}   �� *
Background+$ C�� � 	Resources 5      	 �� Source�� 5   
   $	 TopButStyle.xaml?�6   %    69   .��5
      � -   5        $��Grid_��5
      
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v   �� 5   
   -   5           	TopBorder#��[  5   (   ���	#3F000000��6K   �� *
Foreground+$ 
MainColors��._�5      ]� .+�5      �� -   5        $��Right=�5   1    � ToolTip$ 关闭��6H    
 TopBut#��[ 6U   ._�5      �� $��叉.png��6   6-   5      �� 5      -   5        .��5      �� -   5        $��	TitleText��5       $��	　　　��61   $��Center=�6<   
������� �� TextAlignment$ Center=�6j   $��20(�6�    �� Padding$ 0,5,0,0q�6�   $3 -双击缩放窗口，按住鼠标移动窗口��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5   .   5      5      5       �� 5"   
   -   5        $��MessageText��5"      $��1��6'   $��0q�64   $
��Wrap=�6?   $��15(�6S   ��6a   �� *
Foreground+$ 
MainColors����6�   �� *
Background+$ 
MainColors��6�   ]� 5#   
   ��.  $��2��6*   .+�5$      �� -	   5        $��Right=�5$   -   $	 是��6D     Submit_Smalllab#��[ 6P    �� Padding$ 0q�6�   ��6y   Z� ._�5%      �� $��勾.png��6   6)   5&      5'      5(      5)      