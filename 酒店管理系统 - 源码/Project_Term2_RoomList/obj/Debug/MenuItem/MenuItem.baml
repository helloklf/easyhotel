   M S B A M L   `   `   `  ����  Project_Term2_RoomList.    (Project_Term2_RoomList.MenuItem.MenuItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$
  this��5   A   $��10q�5   E    � 	Resources 5       �� 
TargetType 	  LMenu �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity   Color �� ElementName	 �� 
TargetType
 � 	Resources  Key �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value �� 
Background ��Name �� CornerRadius J� OpacityMask �� EndPoint �� 
StartPoint � Color � Offset �� Triggers ]� 
Conditions �� Property �� Value P� Property P� Value��%:  &	        �� 5   
   " 	�6   .�5	      ��  �@J�Effect 5
        5      $ 2Q�6'   $	 0.5Q�67    6E   �� *
Foreground+$ C��6r   5      �� 5       � ��$	 240��6)   67   �� 5       � ��$	 135��6)   67   �� 5       � ��$	 135��6*   68   �� 5       � ��$ 20(�6)   66   �� 5       � �� 6+   �� *
Foreground+$ C��6X   �� 5       � ��$ Center=�6;   6L   �� 5       � ��$ 2q�60   6<   �� 5       � �� 5      �� 5      "	 	�6&   
 5      ���� 5      Storyboard1 .��5   "   �� $0 *(Panel.Background).(SolidColorBrush.Color)�6?   $ bd��5      .g�5   &     $ 0��6:   $
 #fff��6F     5   &   $ 0:0:0.3��6:   $ Transparent��6L   5   #   5      5       .R�5!      �� 
 ���� ._�5"      �� $ bd��6%   $��Stretch=�61   #��z��6O   #��z��6y   #��z��6�   $ 1��6�    5#   "   �� 5$   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5%   *   � $ Black��67   $ 0Q�6E   � 5&   *   $ White��67   $ 1Q�6E   5'   '   ._�5)   "   �� #��z��63   #��z��6S   #��z��5*      #��z��6D   ��. #��z��5+      #��z��6@   5,      5-      5.      50       51      ]� 52       53      �� 54       �@d�	IsChecked$ falseY�69   6I   �� 55       �@J�IsMouseOver . 6J   ./�57      ��  � �� �#30006C   �� 58       � �� 63   �� *
Foreground+$ C��6`   �� 59       � �� 64   �� *
Background+$ C��6a   5:      ]� 5;       5<      �� 5=       �@d�	IsChecked$ falseY�69   6I   �� 5>       �@J�IsMouseOver .  6K   ./�5@      ��  � �� �#00006C   �� 5A       � �� 63   �� *
Foreground+$ C��6`   �� 5B       � �� 64   Z� 6G   5C      P� 5D       �@d�	IsChecked$
 trueY�6/   . �5E      ��  � �� 63   �� *
Background+$ C��6`   �� 5F       � �� 63   �� *
Foreground+$ C��6`   �� 5G       � �� 64   �� *
Foreground+$ C��6a   5H      5J      5�      .��5�      	� -   5        #��[  5�   ,   $	��240��6K   $	��135��6W   ��5�   
   �� 5�       j� Stretch$ Uniform=�6   -   5        Gi��5�   +   .��5�   
   �� -   5         ��Name$ Ti��5�       �� Padding$ 5q�6S   $��Bottom=�6_   $
��Left=�6z   ��6    �� *
Foreground+$
 this��6�   5�      5�      