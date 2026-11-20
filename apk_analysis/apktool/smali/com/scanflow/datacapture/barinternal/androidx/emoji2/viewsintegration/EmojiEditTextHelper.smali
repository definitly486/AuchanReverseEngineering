.class public final Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditTextHelper;
.super Ljava/lang/Object;
.source "EmojiEditTextHelper.java"


# instance fields
.field private final mEditText:Landroid/widget/EditText;

.field private mEmojiReplaceStrategy:I

.field private mMaxEmojiCount:I

.field private final mTextWatcher:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextWatcher;


# direct methods
.method public constructor <init>(Landroid/widget/EditText;Z)V
    .locals 1

    .line 104
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const v0, 0x7fffffff

    .line 70
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditTextHelper;->mMaxEmojiCount:I

    const/4 v0, 0x0

    .line 71
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditTextHelper;->mEmojiReplaceStrategy:I

    .line 105
    const-string v0, "editText cannot be null"

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 106
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditTextHelper;->mEditText:Landroid/widget/EditText;

    .line 107
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextWatcher;

    invoke-direct {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextWatcher;-><init>(Landroid/widget/EditText;Z)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditTextHelper;->mTextWatcher:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextWatcher;

    .line 108
    invoke-virtual {p1, v0}, Landroid/widget/TextView;->addTextChangedListener(Landroid/text/TextWatcher;)V

    .line 109
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditableFactory;->getInstance()Landroid/text/Editable$Factory;

    move-result-object p2

    invoke-virtual {p1, p2}, Landroid/widget/TextView;->setEditableFactory(Landroid/text/Editable$Factory;)V

    return-void
.end method


# virtual methods
.method public getKeyListener(Landroid/text/method/KeyListener;)Landroid/text/method/KeyListener;
    .locals 1

    .line 153
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiKeyListener;

    if-eqz v0, :cond_0

    return-object p1

    :cond_0
    if-nez p1, :cond_1

    const/4 p1, 0x0

    return-object p1

    .line 162
    :cond_1
    instance-of v0, p1, Landroid/text/method/NumberKeyListener;

    if-eqz v0, :cond_2

    return-object p1

    .line 168
    :cond_2
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiKeyListener;

    invoke-direct {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiKeyListener;-><init>(Landroid/text/method/KeyListener;)V

    return-object v0
.end method

.method public isEnabled()Z
    .locals 1

    .line 230
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditTextHelper;->mTextWatcher:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextWatcher;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextWatcher;->isEnabled()Z

    move-result v0

    return v0
.end method

.method public onCreateInputConnection(Landroid/view/inputmethod/InputConnection;Landroid/view/inputmethod/EditorInfo;)Landroid/view/inputmethod/InputConnection;
    .locals 2

    if-nez p1, :cond_0

    const/4 p1, 0x0

    return-object p1

    .line 187
    :cond_0
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;

    if-eqz v0, :cond_1

    return-object p1

    .line 192
    :cond_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditTextHelper;->mEditText:Landroid/widget/EditText;

    invoke-direct {v0, v1, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiInputConnection;-><init>(Landroid/widget/TextView;Landroid/view/inputmethod/InputConnection;Landroid/view/inputmethod/EditorInfo;)V

    return-object v0
.end method

.method public setEnabled(Z)V
    .locals 1

    .line 243
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiEditTextHelper;->mTextWatcher:Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextWatcher;

    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/emoji2/viewsintegration/EmojiTextWatcher;->setEnabled(Z)V

    return-void
.end method
