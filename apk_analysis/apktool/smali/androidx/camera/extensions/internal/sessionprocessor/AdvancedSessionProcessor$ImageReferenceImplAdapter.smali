.class Landroidx/camera/extensions/internal/sessionprocessor/AdvancedSessionProcessor$ImageReferenceImplAdapter;
.super Ljava/lang/Object;
.source "AdvancedSessionProcessor.java"

# interfaces
.implements Landroidx/camera/extensions/impl/advanced/ImageReferenceImpl;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Landroidx/camera/extensions/internal/sessionprocessor/AdvancedSessionProcessor;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "ImageReferenceImplAdapter"
.end annotation


# instance fields
.field private final mImageReference:Landroidx/camera/extensions/internal/sessionprocessor/ImageReference;


# direct methods
.method constructor <init>(Landroidx/camera/extensions/internal/sessionprocessor/ImageReference;)V
    .locals 0

    .line 609
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public decrement()Z
    .locals 1

    const/4 v0, 0x0

    .line 620
    throw v0
.end method

.method public get()Landroid/media/Image;
    .locals 1

    const/4 v0, 0x0

    .line 626
    throw v0
.end method

.method public increment()Z
    .locals 1

    const/4 v0, 0x0

    .line 615
    throw v0
.end method
