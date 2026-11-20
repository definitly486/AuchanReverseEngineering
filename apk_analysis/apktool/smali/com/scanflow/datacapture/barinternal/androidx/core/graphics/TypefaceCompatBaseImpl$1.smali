.class Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl$1;
.super Ljava/lang/Object;
.source "TypefaceCompatBaseImpl.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl$StyleExtractor;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl;->findBestInfo([Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;I)Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl;)V
    .locals 0

    .line 107
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl$1;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getWeight(Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;)I
    .locals 0

    .line 110
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;->getWeight()I

    move-result p1

    return p1
.end method

.method public bridge synthetic getWeight(Ljava/lang/Object;)I
    .locals 0

    .line 107
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl$1;->getWeight(Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;)I

    move-result p1

    return p1
.end method

.method public isItalic(Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;)Z
    .locals 0

    .line 115
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;->isItalic()Z

    move-result p1

    return p1
.end method

.method public bridge synthetic isItalic(Ljava/lang/Object;)Z
    .locals 0

    .line 107
    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;

    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompatBaseImpl$1;->isItalic(Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;)Z

    move-result p1

    return p1
.end method
