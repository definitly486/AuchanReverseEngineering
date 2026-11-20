.class public Lcrc648e35430423bd4943/GLTextureView;
.super Landroid/view/TextureView;
.source "GLTextureView.java"

# interfaces
.implements Lmono/android/IGCUserPeer;
.implements Landroid/view/TextureView$SurfaceTextureListener;
.implements Landroid/view/View$OnLayoutChangeListener;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 2

    .line 30
    invoke-direct {p0, p1}, Landroid/view/TextureView;-><init>(Landroid/content/Context;)V

    .line 31
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc648e35430423bd4943/GLTextureView;

    if-ne v0, v1, :cond_0

    .line 32
    const-string v0, "Android.Content.Context, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "SkiaSharp.Views.Android.GLTextureView, SkiaSharp.Views.Android"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 2

    .line 22
    invoke-direct {p0, p1, p2}, Landroid/view/TextureView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    .line 23
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc648e35430423bd4943/GLTextureView;

    if-ne v0, v1, :cond_0

    .line 24
    const-string v0, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android"

    filled-new-array {p1, p2}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "SkiaSharp.Views.Android.GLTextureView, SkiaSharp.Views.Android"

    invoke-static {p2, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 2

    .line 14
    invoke-direct {p0, p1, p2, p3}, Landroid/view/TextureView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    .line 15
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc648e35430423bd4943/GLTextureView;

    if-ne v0, v1, :cond_0

    .line 16
    invoke-static {p3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object p3

    filled-new-array {p1, p2, p3}, [Ljava/lang/Object;

    move-result-object p1

    const-string p2, "SkiaSharp.Views.Android.GLTextureView, SkiaSharp.Views.Android"

    const-string p3, "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib"

    invoke-static {p2, p3, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_onAttachedToWindow()V
.end method

.method private native n_onDetachedFromWindow()V
.end method

.method private native n_onLayoutChange(Landroid/view/View;IIIIIIII)V
.end method

.method private native n_onSurfaceTextureAvailable(Landroid/graphics/SurfaceTexture;II)V
.end method

.method private native n_onSurfaceTextureDestroyed(Landroid/graphics/SurfaceTexture;)Z
.end method

.method private native n_onSurfaceTextureSizeChanged(Landroid/graphics/SurfaceTexture;II)V
.end method

.method private native n_onSurfaceTextureUpdated(Landroid/graphics/SurfaceTexture;)V
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 88
    iget-object v0, p0, Lcrc648e35430423bd4943/GLTextureView;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 89
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc648e35430423bd4943/GLTextureView;->refList:Ljava/util/ArrayList;

    .line 90
    :cond_0
    iget-object v0, p0, Lcrc648e35430423bd4943/GLTextureView;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 95
    iget-object v0, p0, Lcrc648e35430423bd4943/GLTextureView;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 96
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public onAttachedToWindow()V
    .locals 0

    .line 38
    invoke-direct {p0}, Lcrc648e35430423bd4943/GLTextureView;->n_onAttachedToWindow()V

    return-void
.end method

.method public onDetachedFromWindow()V
    .locals 0

    .line 45
    invoke-direct {p0}, Lcrc648e35430423bd4943/GLTextureView;->n_onDetachedFromWindow()V

    return-void
.end method

.method public onLayoutChange(Landroid/view/View;IIIIIIII)V
    .locals 0

    .line 80
    invoke-direct/range {p0 .. p9}, Lcrc648e35430423bd4943/GLTextureView;->n_onLayoutChange(Landroid/view/View;IIIIIIII)V

    return-void
.end method

.method public onSurfaceTextureAvailable(Landroid/graphics/SurfaceTexture;II)V
    .locals 0

    .line 52
    invoke-direct {p0, p1, p2, p3}, Lcrc648e35430423bd4943/GLTextureView;->n_onSurfaceTextureAvailable(Landroid/graphics/SurfaceTexture;II)V

    return-void
.end method

.method public onSurfaceTextureDestroyed(Landroid/graphics/SurfaceTexture;)Z
    .locals 0

    .line 59
    invoke-direct {p0, p1}, Lcrc648e35430423bd4943/GLTextureView;->n_onSurfaceTextureDestroyed(Landroid/graphics/SurfaceTexture;)Z

    move-result p1

    return p1
.end method

.method public onSurfaceTextureSizeChanged(Landroid/graphics/SurfaceTexture;II)V
    .locals 0

    .line 66
    invoke-direct {p0, p1, p2, p3}, Lcrc648e35430423bd4943/GLTextureView;->n_onSurfaceTextureSizeChanged(Landroid/graphics/SurfaceTexture;II)V

    return-void
.end method

.method public onSurfaceTextureUpdated(Landroid/graphics/SurfaceTexture;)V
    .locals 0

    .line 73
    invoke-direct {p0, p1}, Lcrc648e35430423bd4943/GLTextureView;->n_onSurfaceTextureUpdated(Landroid/graphics/SurfaceTexture;)V

    return-void
.end method
