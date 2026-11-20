.class Landroid/support/v4/os/IResultReceiver2$Stub$Proxy;
.super Ljava/lang/Object;
.source "IResultReceiver2.java"

# interfaces
.implements Landroid/support/v4/os/IResultReceiver2;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Landroid/support/v4/os/IResultReceiver2$Stub;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "Proxy"
.end annotation


# instance fields
.field private mRemote:Landroid/os/IBinder;


# virtual methods
.method public asBinder()Landroid/os/IBinder;
    .locals 1

    .line 85
    iget-object v0, p0, Landroid/support/v4/os/IResultReceiver2$Stub$Proxy;->mRemote:Landroid/os/IBinder;

    return-object v0
.end method
