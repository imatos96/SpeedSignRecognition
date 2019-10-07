import clr
clr.AddReference('System.Windows.Forms')
from System.Windows.Forms import*
name='rMASTIF'

def RunIme_Click(sender, args):
    
    txt1=str((sender.Tag.lbl3.Text))
    lst=txt1.split(':')
    a1=float(lst[1])
    a2=float(lst[2])
    sender.Tag.lbl3.Text="30:"+str(a1/a2)

    txt2=(sender.Tag.lbl4.Text)
    lst1=txt2.split(':')
    b1=float(lst1[1])
    b2=float(lst1[2])
    sender.Tag.lbl4.Text="40:"+str(b1/b2)

    txt3=(sender.Tag.lbl5.Text)
    lst2=txt3.split(':')
    c=float(lst2[1])
    c2=float(lst2[2])
    sender.Tag.lbl5.Text="50:"+str(c/c2)

    txt4=(sender.Tag.lbl6.Text)
    lst3=txt4.split(':')
    d=float(lst3[1])
    d2=float(lst3[2])
    sender.Tag.lbl6.Text="60:"+str(d/d2)

    txt5=(sender.Tag.lbl7.Text)
    lst4=txt5.split(':')
    e=float(lst4[1])
    e2=float(lst4[2])
    sender.Tag.lbl7.Text="70:"+str(e/e2)

    sender.Tag.lbl8.Text=""
    sender.Tag.lbl9.Text=""
    sender.Tag.lbl10.Text=""
    sender.Tag.lbl12.Text=""
   


def LoadExtension(frm):
    RunIme=ToolStripMenuItem(Name=name, Text='&rMASTIF')
    RunIme.Click += RunIme_Click
    RunIme.Tag=frm
    frm.addedToolStripMenuItem.DropDownItems.Add(RunIme)



   




