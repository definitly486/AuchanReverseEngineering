.class public abstract Lcom/scanflow/ui/ar/a;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private host:Lcom/scanflow/ui/ar/ArOverlayView;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final getHost()Lcom/scanflow/ui/ar/ArOverlayView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/ui/ar/a;->host:Lcom/scanflow/ui/ar/ArOverlayView;

    return-object v0
.end method

.method public onAttached(Lcom/scanflow/ui/ar/ArOverlayView;)V
    .locals 1

    .line 0
    const-string v0, "view"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    iput-object p1, p0, Lcom/scanflow/ui/ar/a;->host:Lcom/scanflow/ui/ar/ArOverlayView;

    return-void
.end method

.method public abstract onDraw(Landroid/graphics/Canvas;)V
.end method

.method public final setHost(Lcom/scanflow/ui/ar/ArOverlayView;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/ui/ar/a;->host:Lcom/scanflow/ui/ar/ArOverlayView;

    return-void
.end method
