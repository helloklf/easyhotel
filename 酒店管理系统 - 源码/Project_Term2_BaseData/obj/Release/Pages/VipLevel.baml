   M S B A M L   `   `   `  ���� Q  MProject_Term2_BaseData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MyControls
MyControls  +    %Project_Term2_BaseData.Pages.VipLevel   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'myclr-namespace:MyControls     -   $��20q�  � 	Resources   �� Source�� $ ../Style.xaml?�%    .��]� $��Center=�$��Center=�$	��450��.+��� $��5q�$	��Top=�._��� -   $	��Tab��$��0q���Z� ��Z� .@��� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $	��Top=�$��新增等级��$��18(�$��	0,10,10,0q����� *
Foreground+ �� ElementName$ C���� $��2��$	��Top=�$��0,5,0,5q����� *
Background+$ C��]� $��2q�.+��� $��等级称号：��   	LeftTitle#��[  �� -    ��Name$ InText�� � ToolTip$4 .等级称号(15字以内)，如：白金会员��  ShortTextBox#��[ ]� $��2q�.+��� $��优惠折率：��#��[  �� $��%��$��Right=�$��Center=�$��15(��� -   $ 
InDisCount�� �� IsInputMethodEnabled .  $ 会员折扣率：0-100��#��[ ]� $��2q�.+��� -    ��Name$ VIPintegralError��$y�	Collapsed=�$��积分无效！��$��Bottom=�$��Center=��� $��所需积分：��#��[  �� -   $ 
InIntegral��$��2q� .  $- '达到该等级所需积分，0到21亿��#��[  �� 	MaxLength$ 10��   MyControls.yes     MyControls.yes   	MouseDown$ Label_MouseDown���� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $	��Top=�$��修改等级��$��18(�$��	0,10,10,0q����� *
Foreground+$ C���� $��2��$	��Top=�$��0,5,0,5q����� *
Background+$ C��]� $��2q�.+��� $��等级称号：��#��[  �� -   $ UpText��$4 .等级称号(15字以内)，如：白金会员��#��[ ]� $��2q�.+��� $��优惠折率：��#��[  �� -   $ 
UpDisCount�� .  $ 会员折扣率：0-100��#��[ $ 10���� $��%��$��Right=�#��[  ]� $��2q�.+��� -	   $ VIPintegralError1��$y�	Collapsed=�$��积分无效！��$��Bottom=�$��Center=��� $��所需积分：��#��[  �� -
   $ 
UpIntegral�� .  $- '达到该等级所需积分，0到21亿��#��[ $ 10���� 	 �� Orientation$	 
Horizontal=�$��Right=�$��5q�.+�   MyControls.Back     MyControls.Back
   	MouseDown$
 
ReturnList��  $ Label_MouseDown_1��]� $	��Top=����#2000$��5q�.+��� $��Right=�.+��� -   $ C��$y�	Collapsed=����� *	ForeColor+���� *	BgColor+�� -    ��Name$ IsCheck��$��5q����� *
Foreground+$ C��   MyControls.B     MyControls.B   	MouseDown$ SelectedItemEnabled��   MyControls.A     MyControls.A   	MouseDown$ SelectedItemEnabledNo���� -    ��Name$ LB��
������� �� SelectedValuePath$ LevelID������ .R��� .+��� $	 
Horizontal=�$y�Visible=�.+��� $	 
Horizontal=�$��Center=�.+��� $��Center=�	编号：�� $��Center=� �� Padding$ 2q����� *	LevelID+�� $��20,0,0,0q�$	 
Horizontal=�$��Center=�.+��� $��Center=�有效性：�� $��Center=�$ 2q����� *	IsValid+�� $	 
Horizontal=�.+��� $��Center=�等级称号：�� $��Center=�$ 2q����� *	LevelName+�� $	 
Horizontal=�.+��� $��Center=�所需积分：�� $��Center=�$ 2q����� *LevelIntegral+�� $	 
Horizontal=�.+��� $��Center=�等级折扣：�� $��Center=�$ 2q����� *VipDiscount+