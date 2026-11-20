.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat;
.super Ljava/lang/Object;
.source "FontsContractCompat.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;,
        Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontFamilyResult;,
        Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontRequestCallback;
    }
.end annotation


# direct methods
.method public static buildTypeface(Landroid/content/Context;Landroid/os/CancellationSignal;[Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;)Landroid/graphics/Typeface;
    .locals 1

    const/4 v0, 0x0

    .line 86
    invoke-static {p0, p1, p2, v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/graphics/TypefaceCompat;->createFromFontInfo(Landroid/content/Context;Landroid/os/CancellationSignal;[Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontInfo;I)Landroid/graphics/Typeface;

    move-result-object p0

    return-object p0
.end method

.method public static fetchFonts(Landroid/content/Context;Landroid/os/CancellationSignal;Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontRequest;)Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontFamilyResult;
    .locals 0

    .line 111
    invoke-static {p2}, Landroidx/camera/core/ImageAnalysis$$ExternalSyntheticBackport0;->m(Ljava/lang/Object;)Ljava/util/List;

    move-result-object p2

    invoke-static {p0, p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontProvider;->getFontFamilyResult(Landroid/content/Context;Ljava/util/List;Landroid/os/CancellationSignal;)Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontFamilyResult;

    move-result-object p0

    return-object p0
.end method

.method public static requestFont(Landroid/content/Context;Ljava/util/List;IZILandroid/os/Handler;Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontRequestCallback;)Landroid/graphics/Typeface;
    .locals 1

    .line 250
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper;

    .line 251
    invoke-static {p5}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/RequestExecutor;->createHandlerExecutor(Landroid/os/Handler;)Ljava/util/concurrent/Executor;

    move-result-object p5

    invoke-direct {v0, p6, p5}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper;-><init>(Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontsContractCompat$FontRequestCallback;Ljava/util/concurrent/Executor;)V

    if-eqz p3, :cond_1

    .line 254
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result p3

    const/4 p5, 0x1

    if-gt p3, p5, :cond_0

    const/4 p3, 0x0

    .line 259
    invoke-interface {p1, p3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontRequest;

    invoke-static {p0, p1, v0, p2, p4}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontRequestWorker;->requestFontSync(Landroid/content/Context;Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontRequest;Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper;II)Landroid/graphics/Typeface;

    move-result-object p0

    return-object p0

    .line 255
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Fallbacks with blocking fetches are not supported for performance reasons"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    :cond_1
    const/4 p3, 0x0

    .line 262
    invoke-static {p0, p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/provider/FontRequestWorker;->requestFontAsync(Landroid/content/Context;Ljava/util/List;ILjava/util/concurrent/Executor;Lcom/scanflow/datacapture/barinternal/androidx/core/provider/CallbackWrapper;)Landroid/graphics/Typeface;

    move-result-object p0

    return-object p0
.end method
