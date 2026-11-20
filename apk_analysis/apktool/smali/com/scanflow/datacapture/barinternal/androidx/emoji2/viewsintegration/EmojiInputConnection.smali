.class final Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;
.super Landroid/view/inputmethod/InputConnectionWrapper;
.source "EmojiInputConnection.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;
    }
.end annotation


# instance fields
.field private final mEmojiCompatDeleteHelper:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;

.field private final mTextView:Landroid/widget/TextView;


# direct methods
.method constructor <init>(Landroid/widget/TextView;Landroid/view/inputmethod/InputConnection;Landroid/view/inputmethod/EditorInfo;)V
    .locals 1

    .line 46
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;-><init>()V

    invoke-direct {p0, p1, p2, p3, v0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;-><init>(Landroid/widget/TextView;Landroid/view/inputmethod/InputConnection;Landroid/view/inputmethod/EditorInfo;Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;)V

    return-void
.end method

.method constructor <init>(Landroid/widget/TextView;Landroid/view/inputmethod/InputConnection;Landroid/view/inputmethod/EditorInfo;Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;)V
    .locals 1

    const/4 v0, 0x0

    .line 55
    invoke-direct {p0, p2, v0}, Landroid/view/inputmethod/InputConnectionWrapper;-><init>(Landroid/view/inputmethod/InputConnection;Z)V

    .line 56
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;->mTextView:Landroid/widget/TextView;

    .line 57
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;->mEmojiCompatDeleteHelper:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;

    .line 58
    invoke-virtual {p4, p3}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;->updateEditorInfoAttrs(Landroid/view/inputmethod/EditorInfo;)V

    return-void
.end method

.method private getEditable()Landroid/text/Editable;
    .locals 1

    .line 77
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;->mTextView:Landroid/widget/TextView;

    invoke-virtual {v0}, Landroid/widget/TextView;->getEditableText()Landroid/text/Editable;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public deleteSurroundingText(II)Z
    .locals 6

    .line 63
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;->mEmojiCompatDeleteHelper:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;

    .line 64
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;->getEditable()Landroid/text/Editable;

    move-result-object v2

    const/4 v5, 0x0

    move-object v1, p0

    move v3, p1

    move v4, p2

    .line 63
    invoke-virtual/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;->handleDeleteSurroundingText(Landroid/view/inputmethod/InputConnection;Landroid/text/Editable;IIZ)Z

    move-result p1

    if-nez p1, :cond_1

    .line 65
    invoke-super {p0, v3, v4}, Landroid/view/inputmethod/InputConnectionWrapper;->deleteSurroundingText(II)Z

    move-result p1

    if-eqz p1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method public deleteSurroundingTextInCodePoints(II)Z
    .locals 6

    .line 71
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;->mEmojiCompatDeleteHelper:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;

    .line 72
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;->getEditable()Landroid/text/Editable;

    move-result-object v2

    const/4 v5, 0x1

    move-object v1, p0

    move v3, p1

    move v4, p2

    .line 71
    invoke-virtual/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection$EmojiCompatDeleteHelper;->handleDeleteSurroundingText(Landroid/view/inputmethod/InputConnection;Landroid/text/Editable;IIZ)Z

    move-result p1

    if-nez p1, :cond_1

    .line 73
    invoke-super {p0, v3, v4}, Landroid/view/inputmethod/InputConnectionWrapper;->deleteSurroundingTextInCodePoints(II)Z

    move-result p1

    if-eqz p1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x1

    return p1
.end method
