package com.zerobranch.layout;

import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Point;
import android.util.AttributeSet;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.FrameLayout;
import androidx.core.view.GestureDetectorCompat;
import androidx.core.view.ViewCompat;
import androidx.customview.widget.ViewDragHelper;

/* JADX INFO: loaded from: classes3.dex */
public class SwipeLayout extends FrameLayout {
    private static final int CLOSE_POSITION = 0;
    private static final int DEFAULT_AUTO_OPEN_SPEED = 1000;
    public static final int HORIZONTAL = 3;
    public static final int LEFT = 1;
    private static final int NO_POSITION = -1;
    public static final int RIGHT = 2;
    private SwipeActionsListener actionsListener;
    private double autoOpenSpeed;
    private int currentDirection;
    private int currentDraggingState;
    private boolean disallowIntercept;
    private ViewDragHelper dragHelper;
    private final ViewDragHelper.Callback dragHelperCallback;
    private View draggedView;
    private int draggedViewId;
    private int draggingViewLeft;
    private GestureDetectorCompat gestureDetector;
    private GestureDetector.OnGestureListener gestureDetectorCallBack;
    private int horizontalWidth;
    private boolean isContinuousSwipe;
    private boolean isEnabledSwipe;
    private boolean isFreeDragAfterOpen;
    private boolean isFreeHorizontalDrag;
    private boolean isLeftOpen;
    private boolean isRightOpen;
    private boolean isTogether;
    private int leftDragViewPadding;
    private int rightDragViewPadding;
    private View staticLeftView;
    private int staticLeftViewId;
    private View staticRightView;
    private int staticRightViewId;

    public interface SwipeActionsListener {
        void onClose();

        void onOpen(int i, boolean z);
    }

    private boolean isDragIdle(int i) {
        return i == 0;
    }

    public SwipeLayout(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        this.currentDraggingState = 0;
        this.gestureDetectorCallBack = new GestureDetector.SimpleOnGestureListener() { // from class: com.zerobranch.layout.SwipeLayout.2
            @Override // android.view.GestureDetector.SimpleOnGestureListener, android.view.GestureDetector.OnGestureListener
            public boolean onScroll(MotionEvent motionEvent, MotionEvent motionEvent2, float f, float f2) {
                if (SwipeLayout.this.getParent() == null) {
                    return false;
                }
                SwipeLayout.this.getParent().requestDisallowInterceptTouchEvent(true);
                return false;
            }
        };
        this.dragHelperCallback = new ViewDragHelper.Callback() { // from class: com.zerobranch.layout.SwipeLayout.3
            @Override // androidx.customview.widget.ViewDragHelper.Callback
            public void onViewDragStateChanged(int i) {
                if (i == SwipeLayout.this.currentDraggingState) {
                    return;
                }
                if (SwipeLayout.this.isIdleAfterMoving(i)) {
                    SwipeLayout.this.updateState();
                }
                SwipeLayout.this.currentDraggingState = i;
            }

            @Override // androidx.customview.widget.ViewDragHelper.Callback
            public void onViewPositionChanged(View view, int i, int i2, int i3, int i4) {
                SwipeLayout.this.draggingViewLeft = i;
                if (SwipeLayout.this.isTogether) {
                    if (SwipeLayout.this.currentDirection == 1) {
                        SwipeLayout.this.staticRightView.offsetLeftAndRight(i3);
                        return;
                    }
                    if (SwipeLayout.this.currentDirection == 2) {
                        SwipeLayout.this.staticLeftView.offsetLeftAndRight(i3);
                    } else if (SwipeLayout.this.currentDirection == 3) {
                        SwipeLayout.this.staticLeftView.offsetLeftAndRight(i3);
                        SwipeLayout.this.staticRightView.offsetLeftAndRight(i3);
                    }
                }
            }

            @Override // androidx.customview.widget.ViewDragHelper.Callback
            public int getViewHorizontalDragRange(View view) {
                return SwipeLayout.this.horizontalWidth;
            }

            @Override // androidx.customview.widget.ViewDragHelper.Callback
            public boolean tryCaptureView(View view, int i) {
                return view.getId() == SwipeLayout.this.draggedView.getId();
            }

            @Override // androidx.customview.widget.ViewDragHelper.Callback
            public int clampViewPositionHorizontal(View view, int i, int i2) {
                if (!SwipeLayout.this.isEnabledSwipe) {
                    return 0;
                }
                int i3 = SwipeLayout.this.currentDirection;
                if (i3 == 1) {
                    return SwipeLayout.this.clampLeftViewPosition(i);
                }
                if (i3 == 2) {
                    return SwipeLayout.this.clampRightViewPosition(i);
                }
                if (i3 != 3) {
                    return 0;
                }
                return SwipeLayout.this.clampHorizontalViewPosition(i, i2);
            }

            @Override // androidx.customview.widget.ViewDragHelper.Callback
            public void onViewReleased(View view, float f, float f2) {
                int finalXHorizontalDirection;
                if (SwipeLayout.this.currentDirection == 1) {
                    finalXHorizontalDirection = SwipeLayout.this.getFinalXLeftDirection(f);
                } else if (SwipeLayout.this.currentDirection == 2) {
                    finalXHorizontalDirection = SwipeLayout.this.getFinalXRightDirection(f);
                } else if (SwipeLayout.this.currentDirection == 3) {
                    finalXHorizontalDirection = SwipeLayout.this.getFinalXHorizontalDirection(f);
                    if (finalXHorizontalDirection == -1) {
                        finalXHorizontalDirection = SwipeLayout.this.getPreviousPosition();
                    }
                } else {
                    finalXHorizontalDirection = 0;
                }
                if (SwipeLayout.this.dragHelper.settleCapturedViewAt(finalXHorizontalDirection, SwipeLayout.this.draggedView.getTop())) {
                    ViewCompat.postInvalidateOnAnimation(SwipeLayout.this);
                }
            }
        };
        this.isLeftOpen = false;
        this.isRightOpen = false;
        TypedArray typedArrayObtainStyledAttributes = getContext().obtainStyledAttributes(attributeSet, R.styleable.SwipeLayout);
        this.currentDirection = typedArrayObtainStyledAttributes.getInteger(R.styleable.SwipeLayout_swipeDirection, 1);
        this.isFreeDragAfterOpen = typedArrayObtainStyledAttributes.getBoolean(R.styleable.SwipeLayout_isFreeDragAfterOpen, false);
        this.isFreeHorizontalDrag = typedArrayObtainStyledAttributes.getBoolean(R.styleable.SwipeLayout_isFreeHorizontalDrag, false);
        this.isContinuousSwipe = typedArrayObtainStyledAttributes.getBoolean(R.styleable.SwipeLayout_isContinuousSwipe, false);
        this.isTogether = typedArrayObtainStyledAttributes.getBoolean(R.styleable.SwipeLayout_isTogether, false);
        this.isEnabledSwipe = typedArrayObtainStyledAttributes.getBoolean(R.styleable.SwipeLayout_isEnabledSwipe, true);
        this.staticLeftViewId = typedArrayObtainStyledAttributes.getResourceId(R.styleable.SwipeLayout_leftItem, 0);
        this.staticRightViewId = typedArrayObtainStyledAttributes.getResourceId(R.styleable.SwipeLayout_rightItem, 0);
        this.draggedViewId = typedArrayObtainStyledAttributes.getResourceId(R.styleable.SwipeLayout_draggedItem, 0);
        this.autoOpenSpeed = typedArrayObtainStyledAttributes.getInt(R.styleable.SwipeLayout_autoMovingSensitivity, 1000);
        this.rightDragViewPadding = (int) typedArrayObtainStyledAttributes.getDimension(R.styleable.SwipeLayout_rightDragViewPadding, 0.0f);
        this.leftDragViewPadding = (int) typedArrayObtainStyledAttributes.getDimension(R.styleable.SwipeLayout_leftDragViewPadding, 0.0f);
        parametersAdjustment();
        typedArrayObtainStyledAttributes.recycle();
    }

    @Override // android.view.View
    protected void onSizeChanged(int i, int i2, int i3, int i4) {
        this.horizontalWidth = i;
        super.onSizeChanged(i, i2, i3, i4);
    }

    @Override // android.view.ViewGroup
    public boolean onInterceptTouchEvent(MotionEvent motionEvent) {
        if (this.disallowIntercept && isViewGroup(this.draggedView)) {
            View neededTouchView = getNeededTouchView(motionEvent, (ViewGroup) this.draggedView);
            Point point = new Point((int) motionEvent.getX(), (int) motionEvent.getY());
            if (neededTouchView != null && isViewTouchTarget(neededTouchView, point)) {
                return false;
            }
        }
        return isSwipeViewTarget(motionEvent) && this.dragHelper.shouldInterceptTouchEvent(motionEvent);
    }

    @Override // android.view.ViewGroup, android.view.ViewParent
    public void requestDisallowInterceptTouchEvent(boolean z) {
        super.requestDisallowInterceptTouchEvent(z);
        this.disallowIntercept = z;
    }

    @Override // android.view.View
    protected void onFinishInflate() {
        int i = this.draggedViewId;
        if (i != 0) {
            this.draggedView = findViewById(i);
        }
        int i2 = this.staticLeftViewId;
        if (i2 != 0) {
            this.staticLeftView = findViewById(i2);
        }
        int i3 = this.staticRightViewId;
        if (i3 != 0) {
            this.staticRightView = findViewById(i3);
        }
        if (this.draggedView == null) {
            throw new RuntimeException("'draggedItem' must be specified");
        }
        boolean z = this.isTogether;
        if (z && this.currentDirection == 1 && this.staticRightView == null) {
            throw new RuntimeException("If 'isTogether = true' 'rightItem' must be specified");
        }
        if (z && this.currentDirection == 2 && this.staticLeftView == null) {
            throw new RuntimeException("If 'isTogether = true' 'leftItem' must be specified");
        }
        int i4 = this.currentDirection;
        if (i4 == 1 && !this.isContinuousSwipe && this.staticRightView == null) {
            throw new RuntimeException("Must be specified 'rightItem' or flag isContinuousSwipe = true");
        }
        if (i4 == 2 && !this.isContinuousSwipe && this.staticLeftView == null) {
            throw new RuntimeException("Must be specified 'leftItem' or flag isContinuousSwipe = true");
        }
        if (i4 == 3 && (this.staticRightView == null || this.staticLeftView == null)) {
            throw new RuntimeException("'leftItem' and 'rightItem' must be specified");
        }
        this.dragHelper = ViewDragHelper.create(this, 1.0f, this.dragHelperCallback);
        this.gestureDetector = new GestureDetectorCompat(getContext(), this.gestureDetectorCallBack);
        setupPost();
        super.onFinishInflate();
    }

    @Override // android.view.View
    public boolean onTouchEvent(MotionEvent motionEvent) {
        if (isSwipeViewTarget(motionEvent) || isMoving()) {
            this.gestureDetector.onTouchEvent(motionEvent);
            this.dragHelper.processTouchEvent(motionEvent);
            return true;
        }
        return super.onTouchEvent(motionEvent);
    }

    @Override // android.view.View
    public void computeScroll() {
        if (this.dragHelper.continueSettling(true)) {
            ViewCompat.postInvalidateOnAnimation(this);
        }
    }

    public boolean isEnabledSwipe() {
        return this.isEnabledSwipe;
    }

    public void setEnabledSwipe(boolean z) {
        this.isEnabledSwipe = z;
    }

    public void openRight(boolean z) {
        if (z) {
            openRight();
            return;
        }
        if (isDragIdle(this.currentDraggingState)) {
            if (((this.currentDirection != 1 || isEmptyRightView()) && this.currentDirection != 3) || this.isRightOpen) {
                return;
            }
            if (this.isTogether) {
                this.staticRightView.offsetLeftAndRight((this.isLeftOpen ? getRightViewWidth() * 2 : getRightViewWidth()) * (-1));
            }
            this.draggedView.offsetLeftAndRight((this.isLeftOpen ? getRightViewWidth() * 2 : getRightViewWidth()) * (-1));
            this.draggingViewLeft -= this.isLeftOpen ? getRightViewWidth() * 2 : getRightViewWidth();
            updateState();
        }
    }

    public void openRightCompletely(boolean z) {
        if (z) {
            openRightCompletely();
            return;
        }
        if (isDragIdle(this.currentDraggingState) && this.currentDirection == 1) {
            if (this.isTogether) {
                this.staticRightView.offsetLeftAndRight(-this.horizontalWidth);
            }
            this.draggedView.offsetLeftAndRight(-this.horizontalWidth);
            this.draggingViewLeft -= this.horizontalWidth;
            updateState();
        }
    }

    public void openLeft(boolean z) {
        if (z) {
            openLeft();
            return;
        }
        if (isDragIdle(this.currentDraggingState)) {
            if (((this.currentDirection != 2 || isEmptyLeftView()) && this.currentDirection != 3) || this.isLeftOpen) {
                return;
            }
            if (this.isTogether) {
                this.staticLeftView.offsetLeftAndRight(this.isRightOpen ? getLeftViewWidth() * 2 : getLeftViewWidth());
            }
            this.draggedView.offsetLeftAndRight(this.isRightOpen ? getLeftViewWidth() * 2 : getLeftViewWidth());
            this.draggingViewLeft += this.isRightOpen ? getLeftViewWidth() * 2 : getLeftViewWidth();
            updateState();
        }
    }

    public void openLeftCompletely(boolean z) {
        if (z) {
            openRightCompletely();
            return;
        }
        if (isDragIdle(this.currentDraggingState) && this.currentDirection == 2) {
            if (this.isTogether) {
                this.staticRightView.offsetLeftAndRight(this.horizontalWidth);
            }
            this.draggedView.offsetLeftAndRight(this.horizontalWidth);
            this.draggingViewLeft += this.horizontalWidth;
            updateState();
        }
    }

    public void close(boolean z) {
        if (z) {
            close();
            return;
        }
        if (this.isTogether) {
            View view = this.staticLeftView;
            if (view != null && this.currentDirection == 2) {
                view.layout(0, view.getTop(), this.staticLeftView.getWidth(), this.staticLeftView.getBottom());
            } else {
                View view2 = this.staticRightView;
                if (view2 != null && this.currentDirection == 1) {
                    view2.layout(this.horizontalWidth - view2.getWidth(), this.staticRightView.getTop(), this.horizontalWidth, this.staticRightView.getBottom());
                } else if (this.currentDirection == 3 && view2 != null && view != null) {
                    view.layout(0, view.getTop(), this.staticLeftView.getWidth(), this.staticLeftView.getBottom());
                    View view3 = this.staticRightView;
                    view3.layout(this.horizontalWidth - view3.getWidth(), this.staticRightView.getTop(), this.horizontalWidth, this.staticRightView.getBottom());
                }
            }
        }
        View view4 = this.draggedView;
        view4.layout(0, view4.getTop(), this.draggedView.getWidth(), this.draggedView.getBottom());
        this.draggingViewLeft = 0;
        updateState();
    }

    public void openLeft() {
        if (isDragIdle(this.currentDraggingState)) {
            if ((this.currentDirection != 2 || isEmptyLeftView()) && this.currentDirection != 3) {
                return;
            }
            moveTo(getLeftViewWidth());
        }
    }

    public void openRight() {
        if (isDragIdle(this.currentDraggingState)) {
            if ((this.currentDirection != 1 || isEmptyRightView()) && this.currentDirection != 3) {
                return;
            }
            moveTo(-getRightViewWidth());
        }
    }

    public void openLeftCompletely() {
        if (isDragIdle(this.currentDraggingState) && this.currentDirection == 2) {
            moveTo(this.horizontalWidth);
        }
    }

    public void openRightCompletely() {
        if (isDragIdle(this.currentDraggingState) && this.currentDirection == 1) {
            moveTo(-this.horizontalWidth);
        }
    }

    public void close() {
        moveTo(0);
    }

    public boolean isMoving() {
        int i = this.currentDraggingState;
        return i == 1 || i == 2;
    }

    public boolean isClosed() {
        return this.draggingViewLeft == 0;
    }

    public int getCurrentDirection() {
        return this.currentDirection;
    }

    public SwipeLayout setCurrentDirection(int i) {
        this.currentDirection = i;
        return this;
    }

    public boolean isTogether() {
        return this.isTogether;
    }

    public SwipeLayout setTogether(boolean z) {
        this.isTogether = z;
        return this;
    }

    public boolean isContinuousSwipe() {
        return this.isContinuousSwipe;
    }

    public SwipeLayout setContinuousSwipe(boolean z) {
        this.isContinuousSwipe = z;
        parametersAdjustment();
        return this;
    }

    public boolean isFreeDragAfterOpen() {
        return this.isFreeDragAfterOpen;
    }

    public SwipeLayout setFreeDragAfterOpen(boolean z) {
        this.isFreeDragAfterOpen = z;
        parametersAdjustment();
        return this;
    }

    public boolean isFreeHorizontalDrag() {
        return this.isFreeHorizontalDrag;
    }

    public SwipeLayout setFreeHorizontalDrag(boolean z) {
        this.isFreeHorizontalDrag = z;
        return this;
    }

    public boolean isRightOpen() {
        return this.isRightOpen;
    }

    public boolean isLeftOpen() {
        return this.isLeftOpen;
    }

    public SwipeLayout setOnActionsListener(SwipeActionsListener swipeActionsListener) {
        this.actionsListener = swipeActionsListener;
        return this;
    }

    public int getRightDragViewPadding() {
        return this.rightDragViewPadding;
    }

    public SwipeLayout setRightDragViewPadding(int i) {
        this.rightDragViewPadding = i;
        parametersAdjustment();
        return this;
    }

    public int getLeftDragViewPadding() {
        return this.leftDragViewPadding;
    }

    public SwipeLayout setLeftDragViewPadding(int i) {
        this.leftDragViewPadding = i;
        parametersAdjustment();
        return this;
    }

    public void enableTouchForViewGroup(ViewGroup viewGroup) {
        viewGroup.setOnTouchListener(new View.OnTouchListener() { // from class: com.zerobranch.layout.SwipeLayout.1
            @Override // android.view.View.OnTouchListener
            public boolean onTouch(View view, MotionEvent motionEvent) {
                SwipeLayout.this.requestDisallowInterceptTouchEvent(true);
                return false;
            }
        });
    }

    /* JADX INFO: Access modifiers changed from: private */
    public void updateState() {
        if (isClosed()) {
            this.isLeftOpen = false;
            this.isRightOpen = false;
            SwipeActionsListener swipeActionsListener = this.actionsListener;
            if (swipeActionsListener != null) {
                swipeActionsListener.onClose();
                return;
            }
            return;
        }
        if (isLeftOpenCompletely() || isLeftViewOpen()) {
            this.isLeftOpen = true;
            this.isRightOpen = false;
            SwipeActionsListener swipeActionsListener2 = this.actionsListener;
            if (swipeActionsListener2 != null) {
                swipeActionsListener2.onOpen(2, isLeftOpenCompletely());
                return;
            }
            return;
        }
        if (isRightOpenCompletely() || isRightViewOpen()) {
            this.isLeftOpen = false;
            this.isRightOpen = true;
            SwipeActionsListener swipeActionsListener3 = this.actionsListener;
            if (swipeActionsListener3 != null) {
                swipeActionsListener3.onOpen(1, isRightOpenCompletely());
            }
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public int clampLeftViewPosition(int i) {
        if (this.isContinuousSwipe && isEmptyRightView()) {
            if (!this.isFreeHorizontalDrag) {
                if (i > 0) {
                    return 0;
                }
                return Math.max(i, -this.horizontalWidth);
            }
            int i2 = this.horizontalWidth;
            if (i > i2) {
                return 0;
            }
            return Math.max(i, -i2);
        }
        if (this.isFreeDragAfterOpen) {
            if (!this.isFreeHorizontalDrag) {
                if (i > 0) {
                    return 0;
                }
                return Math.max(i, this.leftDragViewPadding - this.horizontalWidth);
            }
            int i3 = this.horizontalWidth;
            if (i > i3) {
                return 0;
            }
            return Math.max(i, this.leftDragViewPadding - i3);
        }
        if (this.isFreeHorizontalDrag) {
            if (i > this.horizontalWidth) {
                return 0;
            }
            return Math.max(i, -getRightViewWidth());
        }
        if (i > 0) {
            return 0;
        }
        return Math.max(i, -getRightViewWidth());
    }

    /* JADX INFO: Access modifiers changed from: private */
    public int clampRightViewPosition(int i) {
        if (this.isContinuousSwipe && isEmptyLeftView()) {
            if (this.isFreeHorizontalDrag) {
                int i2 = this.horizontalWidth;
                return i < (-i2) ? -i2 : Math.min(i, i2);
            }
            if (i < 0) {
                return 0;
            }
            return Math.min(i, this.horizontalWidth);
        }
        if (this.isFreeDragAfterOpen) {
            if (this.isFreeHorizontalDrag) {
                int i3 = this.horizontalWidth;
                return i < (-i3) ? -i3 : Math.min(i, i3 - this.rightDragViewPadding);
            }
            if (i < 0) {
                return 0;
            }
            return Math.min(i, this.horizontalWidth - this.rightDragViewPadding);
        }
        if (this.isFreeHorizontalDrag) {
            int i4 = this.horizontalWidth;
            return i < (-i4) ? -i4 : Math.min(i, getLeftViewWidth());
        }
        if (i < 0) {
            return 0;
        }
        return Math.min(i, getLeftViewWidth());
    }

    /* JADX INFO: Access modifiers changed from: private */
    public int clampHorizontalViewPosition(int i, int i2) {
        boolean z = this.isFreeHorizontalDrag;
        if (!z && this.isLeftOpen && i2 < 0) {
            return Math.max(i, 0);
        }
        if (!z && this.isRightOpen && i2 > 0) {
            return Math.min(i, 0);
        }
        boolean z2 = this.isFreeDragAfterOpen;
        if (!z2 && i > 0) {
            return Math.min(i, getLeftViewWidth());
        }
        if (!z2 && i < 0) {
            return Math.max(i, -getRightViewWidth());
        }
        if (i < 0) {
            return Math.max(i, this.leftDragViewPadding - this.horizontalWidth);
        }
        return Math.min(i, this.horizontalWidth - this.rightDragViewPadding);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public int getPreviousPosition() {
        if (this.isLeftOpen) {
            return getLeftViewWidth();
        }
        if (this.isRightOpen) {
            return -getRightViewWidth();
        }
        return 0;
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX WARN: Code duplicated, block: B:19:0x002f  */
    /* JADX WARN: Code duplicated, block: B:22:0x0037  */
    /* JADX WARN: Code duplicated, block: B:32:0x0056  */
    public int getFinalXLeftDirection(float f) {
        double d;
        double d2;
        int rightViewWidth;
        int i;
        int i2;
        if (this.isContinuousSwipe) {
            if (isEmptyRightView()) {
                int i3 = this.draggingViewLeft;
                if ((i3 >= 0 || Math.abs(i3) <= this.horizontalWidth / 2) && f >= (-this.autoOpenSpeed)) {
                    return 0;
                }
                rightViewWidth = this.horizontalWidth;
            } else if (isContinuousSwipeToLeft(f)) {
                rightViewWidth = this.horizontalWidth;
            } else {
                d = f;
                d2 = this.autoOpenSpeed;
                if (d <= d2) {
                    if (d >= (-d2)) {
                        i2 = this.draggingViewLeft;
                        if (i2 < 0) {
                            Math.abs(i2);
                            getRightViewWidth();
                        }
                    }
                    rightViewWidth = getRightViewWidth();
                }
                return 0;
            }
        } else {
            d = f;
            d2 = this.autoOpenSpeed;
            if (d <= d2) {
                if (d >= (-d2) && ((i = this.draggingViewLeft) >= 0 || Math.abs(i) <= getRightViewWidth() / 2)) {
                    i2 = this.draggingViewLeft;
                    if (i2 < 0) {
                        Math.abs(i2);
                        getRightViewWidth();
                    }
                } else {
                    rightViewWidth = getRightViewWidth();
                }
            }
            return 0;
        }
        return -rightViewWidth;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public int getFinalXRightDirection(float f) {
        if (this.isContinuousSwipe) {
            if (isEmptyLeftView()) {
                int i = this.draggingViewLeft;
                if ((i <= 0 || Math.abs(i) <= this.horizontalWidth / 2) && f <= this.autoOpenSpeed) {
                    return 0;
                }
                return this.horizontalWidth;
            }
            if (isContinuousSwipeToRight(f)) {
                return this.horizontalWidth;
            }
        }
        double d = f;
        double d2 = this.autoOpenSpeed;
        if (d <= d2) {
            if (d >= (-d2)) {
                int i2 = this.draggingViewLeft;
                if (i2 <= 0 || Math.abs(i2) <= getLeftViewWidth() / 2) {
                    int i3 = this.draggingViewLeft;
                    if (i3 > 0) {
                        Math.abs(i3);
                        getLeftViewWidth();
                    }
                }
            }
            return 0;
        }
        return getLeftViewWidth();
    }

    /* JADX INFO: Access modifiers changed from: private */
    public int getFinalXHorizontalDirection(float f) {
        if (isSwipeToOpenLeft(f)) {
            return getLeftViewWidth();
        }
        if (isSwipeToOpenRight(f)) {
            return -getRightViewWidth();
        }
        return isSwipeToClose(f) ? 0 : -1;
    }

    private boolean isContinuousSwipeToRight(float f) {
        if (f > this.autoOpenSpeed && Math.abs(this.draggingViewLeft) > getLeftViewWidth()) {
            return true;
        }
        int i = this.draggingViewLeft;
        return i > 0 && Math.abs(i) > this.horizontalWidth / 2;
    }

    private boolean isContinuousSwipeToLeft(float f) {
        if (f < (-this.autoOpenSpeed) && Math.abs(this.draggingViewLeft) > getRightViewWidth()) {
            return true;
        }
        int i = this.draggingViewLeft;
        return i < 0 && Math.abs(i) > this.horizontalWidth / 2;
    }

    private boolean isSwipeToOpenRight(float f) {
        if (f > 0.0f) {
            return false;
        }
        int i = this.draggingViewLeft;
        if (i >= 0 || f >= (-this.autoOpenSpeed)) {
            return i < 0 && Math.abs(i) > getRightViewWidth() / 2;
        }
        return true;
    }

    private boolean isSwipeToOpenLeft(float f) {
        if (f < 0.0f) {
            return false;
        }
        int i = this.draggingViewLeft;
        if (i <= 0 || f <= this.autoOpenSpeed) {
            return i > 0 && Math.abs(i) > getLeftViewWidth() / 2;
        }
        return true;
    }

    private boolean isSwipeToClose(float f) {
        int i = this.draggingViewLeft;
        if (i >= 0 && f < (-this.autoOpenSpeed)) {
            return true;
        }
        if (i <= 0 && f > this.autoOpenSpeed) {
            return true;
        }
        if (i >= 0 && Math.abs(i) < getLeftViewWidth() / 2) {
            return true;
        }
        int i2 = this.draggingViewLeft;
        return i2 <= 0 && Math.abs(i2) < getRightViewWidth() / 2;
    }

    private void setupPost() {
        if (this.isTogether) {
            post(new Runnable() { // from class: com.zerobranch.layout.SwipeLayout.4
                @Override // java.lang.Runnable
                public void run() {
                    if (SwipeLayout.this.currentDirection == 1) {
                        SwipeLayout.this.staticRightView.setX(SwipeLayout.this.horizontalWidth);
                        return;
                    }
                    if (SwipeLayout.this.currentDirection == 2) {
                        SwipeLayout.this.staticLeftView.setX(-SwipeLayout.this.staticLeftView.getWidth());
                    } else if (SwipeLayout.this.currentDirection == 3) {
                        SwipeLayout.this.staticRightView.setX(SwipeLayout.this.horizontalWidth);
                        SwipeLayout.this.staticLeftView.setX(-SwipeLayout.this.staticLeftView.getWidth());
                    }
                }
            });
        }
    }

    private boolean isViewTouchTarget(View view, Point point) {
        return point.y >= view.getTop() && point.y < view.getBottom() && point.x >= view.getLeft() && point.y < view.getRight();
    }

    private View getNeededTouchView(MotionEvent motionEvent, ViewGroup viewGroup) {
        View neededTouchView;
        if (viewGroup.onInterceptTouchEvent(motionEvent)) {
            return viewGroup;
        }
        int childCount = viewGroup.getChildCount();
        for (int i = 0; i < childCount; i++) {
            View childAt = viewGroup.getChildAt(i);
            if (isViewGroup(childAt) && (neededTouchView = getNeededTouchView(motionEvent, (ViewGroup) childAt)) != null) {
                return neededTouchView;
            }
        }
        return null;
    }

    private boolean isViewGroup(View view) {
        return view instanceof ViewGroup;
    }

    private boolean isSwipeViewTarget(MotionEvent motionEvent) {
        int[] iArr = new int[2];
        this.draggedView.getLocationOnScreen(iArr);
        int measuredHeight = iArr[1] + this.draggedView.getMeasuredHeight();
        int i = iArr[1];
        int rawY = (int) motionEvent.getRawY();
        return rawY > i && rawY < measuredHeight;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public boolean isIdleAfterMoving(int i) {
        int i2 = this.currentDraggingState;
        return (i2 == 1 || i2 == 2) && i == 0;
    }

    private boolean isRightViewOpen() {
        return this.staticRightView != null && this.draggingViewLeft == (-getRightViewWidth());
    }

    private boolean isLeftViewOpen() {
        return this.staticLeftView != null && this.draggingViewLeft == getLeftViewWidth();
    }

    private boolean isRightOpenCompletely() {
        return this.draggingViewLeft == (-this.horizontalWidth);
    }

    private boolean isLeftOpenCompletely() {
        return this.draggingViewLeft == this.horizontalWidth;
    }

    private int getLeftViewWidth() {
        return this.staticLeftView.getWidth();
    }

    private int getRightViewWidth() {
        return this.staticRightView.getWidth();
    }

    private boolean isEmptyLeftView() {
        return this.staticLeftView == null;
    }

    private boolean isEmptyRightView() {
        return this.staticRightView == null;
    }

    private void parametersAdjustment() {
        if (this.isContinuousSwipe && this.currentDirection != 3) {
            this.isFreeDragAfterOpen = true;
        }
        if (this.currentDirection == 3) {
            this.rightDragViewPadding = 0;
            this.leftDragViewPadding = 0;
        }
    }

    private void moveTo(int i) {
        ViewDragHelper viewDragHelper = this.dragHelper;
        View view = this.draggedView;
        viewDragHelper.smoothSlideViewTo(view, i, view.getTop());
        ViewCompat.postInvalidateOnAnimation(this);
    }
}
