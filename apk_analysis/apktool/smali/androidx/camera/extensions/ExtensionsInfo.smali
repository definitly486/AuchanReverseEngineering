.class final Landroidx/camera/extensions/ExtensionsInfo;
.super Ljava/lang/Object;
.source "ExtensionsInfo.java"


# instance fields
.field private final mCameraProvider:Landroidx/camera/core/CameraProvider;

.field private mVendorExtenderFactory:Landroidx/camera/extensions/VendorExtenderFactory;


# direct methods
.method constructor <init>(Landroidx/camera/core/CameraProvider;)V
    .locals 0

    .line 64
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 65
    iput-object p1, p0, Landroidx/camera/extensions/ExtensionsInfo;->mCameraProvider:Landroidx/camera/core/CameraProvider;

    .line 66
    new-instance p1, Landroidx/camera/extensions/ExtensionsInfo$$ExternalSyntheticLambda0;

    invoke-direct {p1}, Landroidx/camera/extensions/ExtensionsInfo$$ExternalSyntheticLambda0;-><init>()V

    iput-object p1, p0, Landroidx/camera/extensions/ExtensionsInfo;->mVendorExtenderFactory:Landroidx/camera/extensions/VendorExtenderFactory;

    return-void
.end method
