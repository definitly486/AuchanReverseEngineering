.class public Landroidx/browser/customtabs/CustomTabsSession$PendingSession;
.super Ljava/lang/Object;
.source "CustomTabsSession.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Landroidx/browser/customtabs/CustomTabsSession;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "PendingSession"
.end annotation


# instance fields
.field private final mId:Landroid/app/PendingIntent;


# virtual methods
.method getId()Landroid/app/PendingIntent;
    .locals 1

    .line 548
    iget-object v0, p0, Landroidx/browser/customtabs/CustomTabsSession$PendingSession;->mId:Landroid/app/PendingIntent;

    return-object v0
.end method
