.class public Lcom/scanflow/datacapture/sfdocument/SFCameraView;
.super Landroid/widget/FrameLayout;
.source "SourceFile"


# instance fields
.field private arOverlayView:Lcom/scanflow/ui/ar/ArOverlayView;

.field private copyright:Landroid/widget/TextView;

.field private previewView:Landroidx/camera/view/PreviewView;

.field private textView:Landroid/widget/TextView;

.field private viewFinderView:Lcom/scanflow/ui/ViewFinderView;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 1

    const/4 v0, 0x0

    .line 1
    invoke-direct {p0, p1, v0}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;)V
    .locals 5

    const/4 v0, 0x0

    .line 2
    invoke-direct {p0, p1, p2, v0}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    new-instance v1, Landroidx/camera/view/PreviewView;

    invoke-direct {v1, p1, p2}, Landroidx/camera/view/PreviewView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    new-instance v1, Lcom/scanflow/ui/ViewFinderView;

    invoke-direct {v1, p1, p2}, Lcom/scanflow/ui/ViewFinderView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->viewFinderView:Lcom/scanflow/ui/ViewFinderView;

    new-instance v1, Lcom/scanflow/ui/ar/ArOverlayView;

    invoke-direct {v1, p1, p2}, Lcom/scanflow/ui/ar/ArOverlayView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->arOverlayView:Lcom/scanflow/ui/ar/ArOverlayView;

    new-instance v1, Landroid/widget/TextView;

    invoke-direct {v1, p1, p2}, Landroid/widget/TextView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 v2, 0x11

    invoke-virtual {v1, v2}, Landroid/widget/TextView;->setGravity(I)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    const/high16 v3, 0x41800000    # 16.0f

    invoke-virtual {v1, v3}, Landroid/widget/TextView;->setTextSize(F)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 v3, 0x14

    invoke-virtual {v1, v3, v0, v3, v0}, Landroid/widget/TextView;->setPadding(IIII)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    const-string v4, "#C0C0C0"

    invoke-static {v4}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result v4

    invoke-virtual {v1, v4}, Landroid/widget/TextView;->setTextColor(I)V

    iget-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    const-string v4, "The Scanflow SDK licence validation failed. Your licence key has expired!"

    invoke-virtual {v1, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    new-instance v1, Landroid/widget/TextView;

    invoke-direct {v1, p1, p2}, Landroid/widget/TextView;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;)V

    iput-object v1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->copyright:Landroid/widget/TextView;

    const/16 p1, 0x55

    invoke-virtual {v1, p1}, Landroid/widget/TextView;->setGravity(I)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->copyright:Landroid/widget/TextView;

    const/high16 p2, 0x41200000    # 10.0f

    invoke-virtual {p1, p2}, Landroid/widget/TextView;->setTextSize(F)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->copyright:Landroid/widget/TextView;

    const-string p2, "#FFFFFF"

    invoke-static {p2}, Landroid/graphics/Color;->parseColor(Ljava/lang/String;)I

    move-result p2

    invoke-virtual {p1, p2}, Landroid/widget/TextView;->setTextColor(I)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->copyright:Landroid/widget/TextView;

    invoke-virtual {p1, v0, v0, v3, v3}, Landroid/widget/TextView;->setPadding(IIII)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->copyright:Landroid/widget/TextView;

    sget-object p2, Landroid/graphics/Typeface;->DEFAULT:Landroid/graphics/Typeface;

    invoke-static {p2, v0}, Landroid/graphics/Typeface;->create(Landroid/graphics/Typeface;I)Landroid/graphics/Typeface;

    move-result-object p2

    invoke-virtual {p1, p2}, Landroid/widget/TextView;->setTypeface(Landroid/graphics/Typeface;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->copyright:Landroid/widget/TextView;

    const-string p2, "SCANFLOW"

    invoke-virtual {p1, p2}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    new-instance p1, Landroid/widget/FrameLayout$LayoutParams;

    const/4 p2, -0x1

    invoke-direct {p1, p2, p2, v2}, Landroid/widget/FrameLayout$LayoutParams;-><init>(III)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    invoke-virtual {p0, p2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->arOverlayView:Lcom/scanflow/ui/ar/ArOverlayView;

    invoke-virtual {p0, p2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    invoke-virtual {p0, p2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p2, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->copyright:Landroid/widget/TextView;

    invoke-virtual {p0, p2, p1}, Landroid/view/ViewGroup;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    const/16 p2, 0x8

    invoke-virtual {p1, p2}, Landroid/view/View;->setVisibility(I)V

    iget-object p1, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    invoke-virtual {p1, v0}, Landroid/view/View;->setVisibility(I)V

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V
    .locals 0

    const p3, 0x101005d

    .line 3
    invoke-direct {p0, p1, p2, p3}, Landroid/widget/FrameLayout;-><init>(Landroid/content/Context;Landroid/util/AttributeSet;I)V

    return-void
.end method

.method public static synthetic access$000(Lcom/scanflow/datacapture/sfdocument/SFCameraView;)Landroid/widget/TextView;
    .locals 0

    .line 0
    iget-object p0, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    return-object p0
.end method


# virtual methods
.method public getArOverlayView()Lcom/scanflow/ui/ar/ArOverlayView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->arOverlayView:Lcom/scanflow/ui/ar/ArOverlayView;

    return-object v0
.end method

.method public getPreviewView()Landroidx/camera/view/PreviewView;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->previewView:Landroidx/camera/view/PreviewView;

    return-object v0
.end method

.method public setExpiredVisibility(Ljava/lang/Boolean;Ljava/lang/String;)V
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/sfdocument/SFCameraView;->textView:Landroid/widget/TextView;

    invoke-virtual {v0}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v0

    check-cast v0, Landroid/app/Activity;

    new-instance v1, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;

    invoke-direct {v1, p0, p1, p2}, Lcom/scanflow/datacapture/sfdocument/SFCameraView$1;-><init>(Lcom/scanflow/datacapture/sfdocument/SFCameraView;Ljava/lang/Boolean;Ljava/lang/String;)V

    invoke-virtual {v0, v1}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    return-void
.end method
