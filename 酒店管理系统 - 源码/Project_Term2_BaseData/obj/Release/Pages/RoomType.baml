   M S B A M L   `   `   `  ���� Q  MProject_Term2_BaseData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MyControls
MyControls  +    %Project_Term2_BaseData.Pages.RoomType   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'myclr-namespace:MyControls     -   $��20q�  � 	Resources   �� Source�� $ ../Style.xaml?�%    .��]� $��Center=�$��Center=�$	��450��.+��� $��5q�$	��Top=�._��� -   $	��Tab��$��0q���Z� ��Z� .@��� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $��新增类型��$��18(�$��	0,10,10,0q����� *
Foreground+ �� ElementName$ C���� $��2��$	��Top=�$��0q�$��0,5,0,5q����� *
Background+$ C��]� $��2q�.+��� $��房间类型：��   	LeftTitle#��[  �� -    ��Name$ InText��  ShortTextBox#��[  � ToolTip$" 房间类型，如:贵宾间��]� $��2q�.+��� $��大众单价：��#��[  �� -   $ InPrice��$@ :房间单价(0-21亿)，注:以结算频率为单位时间��#��[ ]� $��2q�.+��� $��VIP 价格：��#��[  �� -   $ 
InVipPrice��$C =VIP优惠单价(0-21亿)，注:以结算频率为单位时间��#��[ ]� $��2q�.+��� $��结算频率：��#��[  �� $��小时��#��[  $��Right=�$��50���� -   $ 
InRequency��$1 +每间隔多久扣费一次，单位:小时��#��[    MyControls.yes     MyControls.yes   	MouseDown$ Label_MouseDown���� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $��新增类型��$��18(�$��	0,10,10,0q����� *
Foreground+$ C���� $��2��$	��Top=�$��0q�$��0,5,0,5q����� *
Background+$ C��]� $��2q�.+��� $��房间类型：��#��[  �� -   $ UpText��$" 房间类型，如:贵宾间��#��[ ]� $��2q�.+��� $��大众单价：��#��[  �� -   $ UpPrice��$@ :房间单价(0-21亿)，注:以结算频率为单位时间��#��[ ]� $��2q�.+��� $��VIP 价格：��#��[  �� -	   $ 
UpVipPrice��$C =VIP优惠单价(0-21亿)，注:以结算频率为单位时间��#��[ ]� $��2q�.+��� $��结算频率：��#��[  �� $��小时��$��Right=�$��50��$��Center=�$��15(��� -
   $ 
UpRequency��$1 +每间隔多久扣费一次，单位:小时��#��[ ��  �� Orientation$ 
Horizontal=�$��Right=�$��5q�.+�   MyControls.Back     MyControls.Back   	MouseDown$ 
ReturnList��  $ Label_MouseDown_1��]� $	��Top=����#2000$��5q�.+��� $��Right=�.+��� -   $ C��$y�	Collapsed=����� *	ForeColor+���� *	BgColor+�� -    ��Name$ IsCheck��$��5q����� *
Foreground+$ C��   MyControls.B     MyControls.B	   	MouseDown$	 SelectedItemEnabled��   MyControls.A     MyControls.A
   	MouseDown$
 SelectedItemEnabledNo���� -    ��Name$ LB��
������� �� SelectedValuePath$ TypeID������ .R��� .+��� $ 
Horizontal=�$y�Visible=�.+��� $ 
Horizontal=�$��Center=�.+��� $��Center=�	编号：�� $��Center=� �� Padding$ 2q����� *TypeID+�� $��Center=�$��20,0,0,0q�房间类型：�� $��Center=�$ 2q����� *
TypeName+�� $��Center=�$��20,0,0,0q�有效性：�� $��Center=�$ 2q����� *	IsValid+�� $ 
Horizontal=�.+��� $��Center=�大众价：�� $��Center=�$
��Wrap=�$ 2q����� *	TypePrice+�� $��Center=�$��20,0,0,0q�
VIP 价：�� $��Center=�$
��Wrap=�$ 2q����� *TypeVipPrice+�� $��Center=�$��20,0,0,0q�结算频率：�� $��Center=�$
��Wrap=�$ 2q����� *TypeRequency+�� $��Center=�小时