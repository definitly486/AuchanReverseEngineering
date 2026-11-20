.class public final synthetic Landroidx/camera/core/ImageAnalysis$$ExternalSyntheticLambda5;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/impl/SessionConfig$ErrorListener;


# instance fields
.field public final synthetic f$0:Landroidx/camera/core/ImageAnalysis;


# direct methods
.method public synthetic constructor <init>(Landroidx/camera/core/ImageAnalysis;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Landroidx/camera/core/ImageAnalysis$$ExternalSyntheticLambda5;->f$0:Landroidx/camera/core/ImageAnalysis;

    return-void
.end method


# virtual methods
.method public final onError(Landroidx/camera/core/impl/SessionConfig;Landroidx/camera/core/impl/SessionConfig$SessionError;)V
    .locals 1

    .line 0
    iget-object v0, p0, Landroidx/camera/core/ImageAnalysis$$ExternalSyntheticLambda5;->f$0:Landroidx/camera/core/ImageAnalysis;

    invoke-static {v0, p1, p2}, Landroidx/camera/core/ImageAnalysis;->$r8$lambda$1CJY_8IUAQO4APWxKL2WqzYKFcc(Landroidx/camera/core/ImageAnalysis;Landroidx/camera/core/impl/SessionConfig;Landroidx/camera/core/impl/SessionConfig$SessionError;)V

    return-void
.end method
