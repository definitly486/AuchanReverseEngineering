.class Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;
.super Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal;
.source "EmojiTextViewHelper.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0xa
    name = "SkippingHelper19"
.end annotation


# instance fields
.field private final mHelperDelegate:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;


# direct methods
.method constructor <init>(Landroid/widget/TextView;)V
    .locals 1

    .line 227
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal;-><init>()V

    .line 228
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;-><init>(Landroid/widget/TextView;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->mHelperDelegate:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;

    return-void
.end method

.method private skipBecauseEmojiCompatNotInitialized()Z
    .locals 1

    .line 232
    invoke-static {}, Landroidx/emoji2/text/EmojiCompat;->isConfigured()Z

    move-result v0

    xor-int/lit8 v0, v0, 0x1

    return v0
.end method


# virtual methods
.method getFilters([Landroid/text/InputFilter;)[Landroid/text/InputFilter;
    .locals 1

    .line 256
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->skipBecauseEmojiCompatNotInitialized()Z

    move-result v0

    if-eqz v0, :cond_0

    return-object p1

    .line 259
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->mHelperDelegate:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;->getFilters([Landroid/text/InputFilter;)[Landroid/text/InputFilter;

    move-result-object p1

    return-object p1
.end method

.method public isEnabled()Z
    .locals 1

    .line 307
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->mHelperDelegate:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;->isEnabled()Z

    move-result v0

    return v0
.end method

.method setAllCaps(Z)V
    .locals 1

    .line 284
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->skipBecauseEmojiCompatNotInitialized()Z

    move-result v0

    if-eqz v0, :cond_0

    return-void

    .line 287
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->mHelperDelegate:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;->setAllCaps(Z)V

    return-void
.end method

.method setEnabled(Z)V
    .locals 1

    .line 298
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->skipBecauseEmojiCompatNotInitialized()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 299
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->mHelperDelegate:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;->setEnabledUnsafe(Z)V

    return-void

    .line 301
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->mHelperDelegate:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;->setEnabled(Z)V

    return-void
.end method

.method wrapTransformationMethod(Landroid/text/method/TransformationMethod;)Landroid/text/method/TransformationMethod;
    .locals 1

    .line 271
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->skipBecauseEmojiCompatNotInitialized()Z

    move-result v0

    if-eqz v0, :cond_0

    return-object p1

    .line 274
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$SkippingHelper19;->mHelperDelegate:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextViewHelper$HelperInternal19;->wrapTransformationMethod(Landroid/text/method/TransformationMethod;)Landroid/text/method/TransformationMethod;

    move-result-object p1

    return-object p1
.end method
