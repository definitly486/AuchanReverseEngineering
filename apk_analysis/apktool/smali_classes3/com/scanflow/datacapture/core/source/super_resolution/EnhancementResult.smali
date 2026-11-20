.class public Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field private final enhancedImages:[Landroid/graphics/Bitmap;


# direct methods
.method public constructor <init>([Landroid/graphics/Bitmap;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;->enhancedImages:[Landroid/graphics/Bitmap;

    return-void
.end method


# virtual methods
.method public getEnhancedImages()[Landroid/graphics/Bitmap;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/core/source/super_resolution/EnhancementResult;->enhancedImages:[Landroid/graphics/Bitmap;

    return-object v0
.end method
