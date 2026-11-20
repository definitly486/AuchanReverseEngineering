.class public abstract Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$Stub;
.super Landroid/os/Binder;
.source "ICustomTabsService.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "Stub"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 75
    invoke-direct {p0}, Landroid/os/Binder;-><init>()V

    .line 76
    sget-object v0, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->DESCRIPTOR:Ljava/lang/String;

    invoke-virtual {p0, p0, v0}, Landroid/os/Binder;->attachInterface(Landroid/os/IInterface;Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method public asBinder()Landroid/os/IBinder;
    .locals 0

    .line 95
    return-object p0
.end method

.method public onTransact(ILandroid/os/Parcel;Landroid/os/Parcel;I)Z
    .locals 3

    .line 99
    sget-object v0, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->DESCRIPTOR:Ljava/lang/String;

    const/4 v1, 0x1

    if-lt p1, v1, :cond_0

    const v2, 0xffffff

    if-gt p1, v2, :cond_0

    .line 101
    invoke-virtual {p2, v0}, Landroid/os/Parcel;->enforceInterface(Ljava/lang/String;)V

    :cond_0
    const v2, 0x5f4e5446

    if-ne p1, v2, :cond_1

    .line 104
    invoke-virtual {p3, v0}, Landroid/os/Parcel;->writeString(Ljava/lang/String;)V

    return v1

    :cond_1
    packed-switch p1, :pswitch_data_0

    .line 268
    invoke-super {p0, p1, p2, p3, p4}, Landroid/os/Binder;->onTransact(ILandroid/os/Parcel;Landroid/os/Parcel;I)Z

    move-result p1

    return p1

    .line 256
    :pswitch_0
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 258
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p4

    .line 260
    sget-object v0, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 261
    invoke-interface {p0, p1, p4, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->setEngagementSignalsCallback(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/IBinder;Landroid/os/Bundle;)Z

    move-result p1

    .line 262
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 263
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto/16 :goto_0

    .line 245
    :pswitch_1
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 247
    sget-object p4, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, p4}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 248
    invoke-interface {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->isEngagementSignalsApiAvailable(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z

    move-result p1

    .line 249
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 250
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto/16 :goto_0

    .line 230
    :pswitch_2
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 232
    sget-object p4, Landroid/net/Uri;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, p4}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p4

    check-cast p4, Landroid/net/Uri;

    .line 234
    invoke-virtual {p2}, Landroid/os/Parcel;->readInt()I

    move-result v0

    .line 236
    sget-object v2, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, v2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 237
    invoke-interface {p0, p1, p4, v0, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->receiveFile(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;ILandroid/os/Bundle;)Z

    move-result p1

    .line 238
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 239
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto/16 :goto_0

    .line 189
    :pswitch_3
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 191
    sget-object p4, Landroid/net/Uri;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, p4}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p4

    check-cast p4, Landroid/net/Uri;

    .line 193
    sget-object v0, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 194
    invoke-interface {p0, p1, p4, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->requestPostMessageChannelWithExtras(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;Landroid/os/Bundle;)Z

    move-result p1

    .line 195
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 196
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto/16 :goto_0

    .line 130
    :pswitch_4
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 132
    sget-object p4, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, p4}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 133
    invoke-interface {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->newSessionWithExtras(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z

    move-result p1

    .line 134
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 135
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto/16 :goto_0

    .line 215
    :pswitch_5
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 217
    invoke-virtual {p2}, Landroid/os/Parcel;->readInt()I

    move-result p4

    .line 219
    sget-object v0, Landroid/net/Uri;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/net/Uri;

    .line 221
    sget-object v2, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, v2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 222
    invoke-interface {p0, p1, p4, v0, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->validateRelationship(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;ILandroid/net/Uri;Landroid/os/Bundle;)Z

    move-result p1

    .line 223
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 224
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto/16 :goto_0

    .line 202
    :pswitch_6
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 204
    invoke-virtual {p2}, Landroid/os/Parcel;->readString()Ljava/lang/String;

    move-result-object p4

    .line 206
    sget-object v0, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 207
    invoke-interface {p0, p1, p4, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->postMessage(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Ljava/lang/String;Landroid/os/Bundle;)I

    move-result p1

    .line 208
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 209
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto/16 :goto_0

    .line 178
    :pswitch_7
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 180
    sget-object p4, Landroid/net/Uri;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, p4}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/net/Uri;

    .line 181
    invoke-interface {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->requestPostMessageChannel(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;)Z

    move-result p1

    .line 182
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 183
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto/16 :goto_0

    .line 167
    :pswitch_8
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 169
    sget-object p4, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, p4}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 170
    invoke-interface {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->updateVisuals(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/os/Bundle;)Z

    move-result p1

    .line 171
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 172
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto :goto_0

    .line 156
    :pswitch_9
    invoke-virtual {p2}, Landroid/os/Parcel;->readString()Ljava/lang/String;

    move-result-object p1

    .line 158
    sget-object p4, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, p4}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/os/Bundle;

    .line 159
    invoke-interface {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->extraCommand(Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object p1

    .line 160
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 161
    invoke-static {p3, p1, v1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$100(Landroid/os/Parcel;Landroid/os/Parcelable;I)V

    goto :goto_0

    .line 141
    :pswitch_a
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 143
    sget-object p4, Landroid/net/Uri;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, p4}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object p4

    check-cast p4, Landroid/net/Uri;

    .line 145
    sget-object v0, Landroid/os/Bundle;->CREATOR:Landroid/os/Parcelable$Creator;

    invoke-static {p2, v0}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService$_Parcel;->access$000(Landroid/os/Parcel;Landroid/os/Parcelable$Creator;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Landroid/os/Bundle;

    .line 147
    invoke-virtual {p2, v0}, Landroid/os/Parcel;->createTypedArrayList(Landroid/os/Parcelable$Creator;)Ljava/util/ArrayList;

    move-result-object p2

    .line 148
    invoke-interface {p0, p1, p4, v2, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->mayLaunchUrl(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;Landroid/net/Uri;Landroid/os/Bundle;Ljava/util/List;)Z

    move-result p1

    .line 149
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 150
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto :goto_0

    .line 121
    :pswitch_b
    invoke-virtual {p2}, Landroid/os/Parcel;->readStrongBinder()Landroid/os/IBinder;

    move-result-object p1

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback$Stub;->asInterface(Landroid/os/IBinder;)Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;

    move-result-object p1

    .line 122
    invoke-interface {p0, p1}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->newSession(Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsCallback;)Z

    move-result p1

    .line 123
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 124
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    goto :goto_0

    .line 112
    :pswitch_c
    invoke-virtual {p2}, Landroid/os/Parcel;->readLong()J

    move-result-wide p1

    .line 113
    invoke-interface {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/android/support/customtabs/ICustomTabsService;->warmup(J)Z

    move-result p1

    .line 114
    invoke-virtual {p3}, Landroid/os/Parcel;->writeNoException()V

    .line 115
    invoke-virtual {p3, p1}, Landroid/os/Parcel;->writeInt(I)V

    :goto_0
    return v1

    nop

    :pswitch_data_0
    .packed-switch 0x2
        :pswitch_c
        :pswitch_b
        :pswitch_a
        :pswitch_9
        :pswitch_8
        :pswitch_7
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method
